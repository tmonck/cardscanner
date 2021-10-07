class MtgCardForeignName {
  MtgCardForeignName({required this.name, required this.imageUrl, required this.language, this.multiverseid});
  String name = "";
  String imageUrl = "";
  String language = "";
  int? multiverseid;
  factory MtgCardForeignName.fromJson(Map<String, dynamic> json) {
    return new MtgCardForeignName(
        name: json['name'],
        imageUrl: json['imageUrl'],
        language: json['language'],
        multiverseid: json['multiversid']
    );
  }
}