import 'dart:io';
import 'dart:convert';

import 'package:flutter/material.dart';
import 'package:google_ml_kit/google_ml_kit.dart';
import 'package:tcg_scanner2/Models/mtg/card/mtg_cards.dart';
import 'package:tcg_scanner2/VisionDetectorViews/mtg_response_view.dart';

import 'camera_view.dart';
import 'painters/text_detector_painter.dart';
import 'package:http/http.dart' as http;

class TextDetectorView extends StatefulWidget {
  @override
  _TextDetectorViewState createState() => _TextDetectorViewState();
}

class _TextDetectorViewState extends State<TextDetectorView> {
  TextDetector textDetector = GoogleMlKit.vision.textDetector();
  bool isBusy = false;
  CustomPaint? customPaint;
  String cardName = "";
  String cardSetCode = "";
  String cardNum = "";
  bool cardNameUnchanged = false;
  bool cardSetAndNumUnchanged = false;

  @override
  void dispose() async {
    super.dispose();
    await textDetector.close();
  }

  @override
  Widget build(BuildContext context) {
    return CameraView(
      title: 'Text Detector',
      customPaint: customPaint,
      onImage: (inputImage) {
        processImage(inputImage);
      }
    );
  }

  Future<void> processImage(InputImage inputImage) async {
    if (isBusy) return;
    isBusy = true;
    final recognisedText = await textDetector.processImage(inputImage);
    print('Found ${recognisedText.blocks.length} textBlocks');
    if (recognisedText.blocks.length >= 6) {
      bool canProceed = firstPersonalFunc(recognisedText.blocks);
      if (canProceed && inputImage.inputImageData?.size != null &&
          inputImage.inputImageData?.imageRotation != null) {
        final painter = TextDetectorPainter(
            recognisedText,
            inputImage.inputImageData!.size,
            inputImage.inputImageData!.imageRotation);
        customPaint = CustomPaint(painter: painter);
      } else {
        customPaint = null;
      }
      if (cardSetAndNumUnchanged && cardNameUnchanged) {
        var cardNumber = int.parse(cardNum);
        final queryParams = {
          'name': cardName,
          // TODO: Once caching is in place use the following params to filter the result set.
          'set': cardSetCode,
          'number': '$cardNumber'
        };

        Uri requestUri = Uri(scheme: 'https', host: 'api.magicthegathering.io', path: 'v1/cards', queryParameters: queryParams);
        final response = await http.get(requestUri);
        if (response.statusCode >= 200 && response.statusCode <= 299) {
          if (response.headers.keys.any((element) => element == 'total-count'))
            print('total-count ${response.headers['total-count']}');
          if (response.headers.keys.any((element) => element == 'page-size'))
            print('page-size ${response.headers['page-size']}');
          if (response.headers.keys.any((element) => element == 'count'))
            print('count ${response.headers['count']}');
          if (response.headers.keys.any((element) => element == 'ratelimit-limit'))
            print('ratelimit-limit ${response.headers['ratelimit-limit']}');
          if (response.headers.keys.any((element) => element == 'ratelimit-remaining'))
            print('ratelimit-remaining ${response.headers['ratelimit-remaining']}');
          final Map<String, dynamic> jsonBody = json.decode(response.body);
          final cards = MtgCards.fromJson(jsonBody);
          if (cards.cards.length == 1) {
            Navigator.push(context,
            MaterialPageRoute(builder: (context) => MtgResponseView(card: cards.cards[0])));
          }
          print('cards count ${cards.cards.length}');
        }
        print('Finished making the request');
      }
    }
    isBusy = cardName.isNotEmpty && cardNum.isNotEmpty && cardSetCode.isNotEmpty && cardNameUnchanged && cardSetAndNumUnchanged;
    if (mounted) {
      setState(() {});
    }
  }

  bool firstPersonalFunc(List<TextBlock> foundText) {
    RegExp regex = RegExp(r"(^\d.*)\/.*\n([a-zA-Z]*)\s", multiLine: true);
    bool hasAllData = false;
    foundText.asMap().forEach((index, data) {
      if (index == 0) {
        print('Card name is ${data.text}');
        if (cardName == data.text)
          cardNameUnchanged = true;
        cardName = data.text;
      }
      else if (regex.hasMatch(data.text)) {
        final match = regex.firstMatch(data.text);
        print('Card number is ${match?.group(1)} and Card Set is ${match?.group(2)}');
        if (cardNum == match?.group(1) && cardSetCode == match?.group(2))
          cardSetAndNumUnchanged = true;
        cardNum = match?.group(1) ?? "";
        cardSetCode = match?.group(2) ?? "";
      }
      else {
        print('Ignoring text block at index $index');
        print('Index $index has text of ${data.text}');
      }
    });
    hasAllData = cardName.isNotEmpty && cardNum.isNotEmpty && cardSetCode.isNotEmpty;
    return hasAllData;
  }
}
