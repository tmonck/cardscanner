import 'dart:convert';
import 'dart:io';

import 'package:tcg_scanner2/Models/collection.dart';
import 'package:tcg_scanner2/Models/mtg/card/mtg_card.dart';
import 'package:tcg_scanner2/Models/mtg/card/mtg_cards.dart';
import 'package:path_provider/path_provider.dart'


class Collections {
  Future<String> get _localPath async {
    final directory = await getApplicationDocumentsDirectory();
    var collectionsDir = new Directory('$directory/collections');
    if(!collectionsDir.existsSync()) {
      collectionsDir.createTempSync();
    }
    return collectionsDir.path;
  }

  Future<File> _collectionFile({required name}) async {
    final directory = _localPath;
    final file = File('$directory/$name.json');
    if (!file.existsSync()) {
      file.createSync();
    }
    return file;
  }

  // TODO: Does this actually write the correct information to file? Maybe.
  Future<Collection> addCardToCollection<T>({required String name, required T card}) async {
    final currentCollection = await getCollection<T>(name: name);
    currentCollection.cards.add(card);
    final file = await _collectionFile(name: name);
    var jsonString = jsonEncode(currentCollection);
    file.writeAsStringSync(jsonString);
    return currentCollection;
  }

  Future<Collection> getCollection<T>({ required name}) async {
    final file = await _collectionFile(name: name);
    final jsonString = await file.readAsString();
    final Map<String, dynamic> jsonBody = jsonDecode(jsonString);
    final collection = Collection.fromJson(T, jsonBody);
    return collection;
  }

  Future<void> deleteCollection({required String name}) async {
    final file = await _collectionFile(name: name);
    file.deleteSync();
  }
}