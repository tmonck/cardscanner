import 'package:flutter/cupertino.dart';
import 'package:flutter/material.dart';
import 'package:tcg_scanner2/Models/mtg/card/mtg_card.dart';
import 'package:tcg_scanner2/VisionDetectorViews/detector_views.dart';

class MtgResponseView extends StatelessWidget {
  final MtgCard card;
  MtgResponseView({Key? key, required this.card});

  List<Text> _buildLegalities() {
    List<Text> tiles = [];
    card.legalities!.forEach((element) {
      tiles.add(
          Text( '${element.format} - ${element.legality}' )
      );
    });
    return tiles;
  }

  List<Text> _buildRulings() {
    List<Text> tiles = [];
    card.rulings!.forEach((element) {
      tiles.add(
          Text( '${element.text} - ${element.date}' )
      );
    });
    return tiles;
  }

  @override
  Widget build(BuildContext context) {
    return new Scaffold(appBar: AppBar(
        leading: IconButton(
          onPressed: () {
            Navigator.push(context, MaterialPageRoute(builder: (context) => TextDetectorView()));
          }, icon: Icon(Icons.arrow_back),
        ),
        title: Text('MTG Card Result')),
        body: SafeArea(
          child: Center(
              child: SingleChildScrollView(
              child: Column(
                children: [
                  Image.network(card.imageUrl ?? ""),
                  ExpansionTile(
                    title: Text('${card.name}'),
                    children: [
                      Text('Card Number: ${card.number}'),
                      Text('Mana Cost: ${card.manaCost}'),
                      Text('Rarity: ${card.rarity}'),
                      Text('Set: ${card.setName}'),
                      Text('Type: ${card.type}'),
                      Text('Power/Toughness: ${card.power} / ${card.toughness}'),
                    ]
                  ),
                  ExpansionTile(
                    title: Text('Legalities'),
                    children:[
                      ..._buildLegalities()
                    ]
                  )
                ],
              )),
          ),
        )
    );
  }

}