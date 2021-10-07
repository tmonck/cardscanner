import 'package:flutter/cupertino.dart';
import 'package:flutter/material.dart';
import 'package:tcg_scanner2/VisionDetectorViews/detector_views.dart';

class Home extends StatefulWidget {
  @override
  HomeState createState() => HomeState();
}

class HomeState extends State<Home> {
  int _selectedIndex = 0;

  List<Widget> _widgetOptions = <Widget> [
    Home(),
    TextDetectorView()
  ];

  @override
  Widget build(BuildContext context) {
    return Scaffold(
    // debugShowCheckedModeBanner: false,
    // home: Home(),
      bottomNavigationBar: BottomNavigationBar(
        currentIndex: _selectedIndex,
        showSelectedLabels: false,
        showUnselectedLabels: true,
        items: const <BottomNavigationBarItem>[
          BottomNavigationBarItem(icon: Icon(Icons.home), label: 'Home'),
          BottomNavigationBarItem(icon: Icon(Icons.camera), label: 'MTG'),
          BottomNavigationBarItem(icon: Icon(Icons.list), label: 'Pokemon'),
        ],
        onTap: (index) {
          setState(() {
            _selectedIndex = index;
          });
        },
      ),
      body: _widgetOptions.elementAt(_selectedIndex)
  );
  }

}