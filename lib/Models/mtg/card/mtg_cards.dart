import 'package:tcg_scanner2/Models/mtg/card/mtg_card.dart';

class MtgCards {
  List<MtgCard> cards;
  MtgCards({required this.cards});
  factory MtgCards.fromJson(Map<String, dynamic> json) {
    if(json['cards'] is List) {
      var mtgCardsFromJson = json['cards'] as List;
      List<MtgCard> cards = mtgCardsFromJson.map((mtgCard) => MtgCard.fromJson(mtgCard)).toList();
      return MtgCards(cards: cards);
      // return MtgCards(cards: [
      //   ...mtgCardsFromJson
      //       .cast<Map<String, Object>>()
      //       .map((i) => MtgCard.fromJson(i))
      // ]);
    } else {
      return MtgCards(cards: []);
    }
  }
}