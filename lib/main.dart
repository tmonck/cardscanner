import 'dart:io';

import 'package:camera/camera.dart';
import 'package:tcg_scanner2/home.dart';
import 'package:tcg_scanner2/home_old.dart';

import 'VisionDetectorViews/detector_views.dart';
import 'package:flutter/material.dart';

List<CameraDescription> cameras = [];

Future<void> main() async {
  WidgetsFlutterBinding.ensureInitialized();

  cameras = await availableCameras();
  runApp(MyApp());
}

class MyApp extends StatelessWidget {
  @override
  Widget build(BuildContext context) {
    return MaterialApp(
      debugShowCheckedModeBanner: false,
      home: Home(),
    );
  }
}

// class Home extends StatelessWidget {
//   @override
//   Widget build(BuildContext context) {
//     return Scaffold(
//       // appBar: AppBar(
//       //   title: Text('TCG Card Scanner'),
//       //   centerTitle: true,
//       //   elevation: 0,
//       // ),
//       bottomNavigationBar: BottomNavigationBar(
//         items: const <BottomNavigationBarItem>[
//           BottomNavigationBarItem(icon: Icon(Icons.home), label: 'Home'),
//           BottomNavigationBarItem(icon: Icon(Icons.camera), label: 'MTG'),
//           BottomNavigationBarItem(icon: Icon(Icons.list), label: 'Pokemone'),
//         ]
//       ),
//       onTap: (index) {
//         setState(() {
//           _selectedIndex = index
//         })
//       },
//       body: _widgetOptions.elementAt(_selectedIndex)
//       // body: SafeArea(
//       //   child: Center(
//       //     child: SingleChildScrollView(
//       //       child: Padding(
//       //         padding: EdgeInsets.symmetric(horizontal: 16),
//       //         child: Column(
//       //           children: [
//       //             ExpansionTile(
//       //               title: const Text("Vision"),
//       //               children: [
//       //                 CustomCard(
//       //                   'Barcode Scanner',
//       //                   BarcodeScannerView(),
//       //                   featureCompleted: true,
//       //                 ),
//       //                 CustomCard(
//       //                   'Text Detector',
//       //                   TextDetectorView(),
//       //                   featureCompleted: true,
//       //                 ),
//       //               ],
//       //             ),
//       //             SizedBox(
//       //               height: 20,
//       //             ),
//       //           ],
//       //         ),
//       //       ),
//       //     ),
//       //   ),
//       // ),
//     );
//   }
// }
//
// class CustomCard extends StatelessWidget {
//   final String _label;
//   final Widget _viewPage;
//   final bool featureCompleted;
//
//   const CustomCard(this._label, this._viewPage,
//       {this.featureCompleted = false});
//
//   @override
//   Widget build(BuildContext context) {
//     return Card(
//       elevation: 5,
//       margin: EdgeInsets.only(bottom: 10),
//       child: ListTile(
//         tileColor: Theme.of(context).primaryColor,
//         title: Text(
//           _label,
//           style: TextStyle(color: Colors.white, fontWeight: FontWeight.bold),
//         ),
//         onTap: () {
//           if (Platform.isIOS && !featureCompleted) {
//             ScaffoldMessenger.of(context).showSnackBar(SnackBar(
//                 content: const Text(
//                     'This feature has not been implemented for iOS yet')));
//           } else
//             Navigator.push(
//                 context, MaterialPageRoute(builder: (context) => _viewPage));
//         },
//       ),
//     );
//   }
// }
