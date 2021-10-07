class MtgCardLegality {
  MtgCardLegality({required this.format, required this.legality});
  String format = "";
  String legality = "";

  factory MtgCardLegality.fromJson(Map<String, dynamic> json) {
    return new MtgCardLegality(format: json['format'], legality: json['legality']);
  }
}