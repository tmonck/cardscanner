class MtgCardRuling {
  MtgCardRuling({required this.date, required this.text});
  DateTime date = DateTime.now();
  String text = "";

  factory MtgCardRuling.fromJson(Map<String, dynamic> json) {
    var date = DateTime.parse(json['date']);
    return MtgCardRuling(date: date, text: json['text']);
  }
}