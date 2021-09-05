import 'dart:convert';
import 'dart:core';

import 'package:tcg_scanner2/Models/mtg/card/mtg_card_foreign_name.dart';
import 'package:tcg_scanner2/Models/mtg/card/mtg_card_legality.dart';
import 'package:tcg_scanner2/Models/mtg/card/mtg_card_ruling.dart';

class MtgCard {
  MtgCard();
   String? id;
   String name = "";
   List<String>? names;
   String manaCost = "";
   int? cmc;
   List<String>? colors;
   List<String>? colorIdentity;
   String type = "";
   List<String>? supertypes;
   List<String> types = [];
   List<String>? subtypes;
   String rarity = "";
   String set = "";
   String setName = "";
   String? text;
   String artist = "";
   String? number;
   String? power;
   String? toughness;
   String? loyalty;
   int? multiverseid;
   String? imageUrl;
   String layout = "";
   List<MtgCardLegality>? legalities;
   List<MtgCardRuling>? rulings;
   List<MtgCardForeignName>? foreignNames;

   factory MtgCard.fromJson(Map<String, dynamic> json) {
     final card = MtgCard();
     card.id = json['id'];
     card.name = json['name'];
     card.names = json['names'];
     card.manaCost = json['manaCost'] ?? "";
     card.cmc = json['cmc'].toInt();
     card.colors = ((json['colors'] ?? []) as List).map((color) => color as String).toList();
     card.colorIdentity = ((json['colorIdentity'] ?? []) as List).map((color) => color.toString()).toList();
     card.type = json['type'];
     // card.supertypes = ((json['supertypes'] ?? [])).map((supertype) => supertype as String).toList();
     card.types = ((json['types'] ?? []) as List).map((type) => type.toString()).toList();
     card.subtypes = ((json['subtypes'] ?? []) as List).map((subtype) => subtype.toString()).toList();
     card.rarity = json['rarity'];
     card.set = json['set'];
     card.setName = json['setName'];
     card.text = json['text'];
     card.artist = json['artist'];
     card.number = json['number'];
     card.power = json['power'];
     card.toughness = json['toughness'];
     card.loyalty = json['loyalty'];
     card.multiverseid = int.parse(json['multiverseid']);
     card.imageUrl = json['imageUrl'];
     card.layout = json['layout'];
     // TODO: Requires testing of each one
     card.legalities = ((json['legalities'] ?? []) as List).map((legal) => MtgCardLegality.fromJson(legal)).toList();
     card.rulings = ((json['rulings'] ?? []) as List).map((rule) => MtgCardRuling.fromJson(rule)).toList();
     card.foreignNames = ((json['foreignNames'] ?? []) as List).map((foreignName) => MtgCardForeignName.fromJson(foreignName)).toList();
     return card;
   }
}