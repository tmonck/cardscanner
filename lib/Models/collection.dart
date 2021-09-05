import 'package:tcg_scanner2/Models/mtg/card/mtg_card.dart';

class Collection<T>  {
  Collection({required this.type});
  String type;
  String jsonListCards = "";
  List<T> cards = [];
  factory Collection.fromJson(T, Map<String, dynamic> json) {
    final collection = new Collection(type: json['type']);
    collection.jsonListCards = json['jsonListCards'];
    collection.cards = T.fromJson(json['jsonListCards'] as List);
    return
  }
}