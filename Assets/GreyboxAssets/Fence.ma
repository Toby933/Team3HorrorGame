//Maya ASCII 2016 scene
//Name: Fence.ma
//Last modified: Mon, Oct 10, 2016 02:23:34 PM
//Codeset: 1252
requires maya "2016";
currentUnit -l centimeter -a degree -t film;
fileInfo "application" "maya";
fileInfo "product" "Maya 2016";
fileInfo "version" "2016";
fileInfo "cutIdentifier" "201511301000-979500";
fileInfo "osv" "Microsoft Windows 7 Enterprise Edition, 64-bit Windows 7 Service Pack 1 (Build 7601)\n";
fileInfo "license" "education";
createNode transform -n "pCube1";
	rename -uid "881857AD-493B-7BC7-DAF2-B788B3C954B3";
	setAttr ".t" -type "double3" 0 74.889730434024443 0 ;
	setAttr ".s" -type "double3" 0.14200163343932098 1.5 0.1354076968331506 ;
createNode transform -n "transform5" -p "pCube1";
	rename -uid "867E3209-492A-20F3-F6A6-CFB01BA77827";
	setAttr ".v" no;
createNode mesh -n "pCubeShape1" -p "transform5";
	rename -uid "CED56D19-4377-C559-A41F-198C7B952594";
	setAttr -k off ".v";
	setAttr ".io" yes;
	setAttr -s 2 ".iog[0].og";
	setAttr ".vir" yes;
	setAttr ".vif" yes;
	setAttr ".uvst[0].uvsn" -type "string" "map1";
	setAttr ".cuvs" -type "string" "map1";
	setAttr ".dcc" -type "string" "Ambient+Diffuse";
	setAttr ".covm[0]"  0 1 1;
	setAttr ".cdvm[0]"  0 1 1;
createNode transform -n "pCube2";
	rename -uid "2531B436-402B-21A4-5BD7-F0869878ABC8";
	setAttr ".t" -type "double3" 200 74.889730434024443 0 ;
	setAttr ".s" -type "double3" 0.14200163343932098 1.5 0.1354076968331506 ;
createNode transform -n "transform4" -p "pCube2";
	rename -uid "2665F1BE-4FB5-6A20-0141-2184FBD4D981";
	setAttr ".v" no;
createNode mesh -n "pCubeShape2" -p "transform4";
	rename -uid "D8BE25AF-4BED-7423-B6A4-EEBCA60E51A8";
	setAttr -k off ".v";
	setAttr ".io" yes;
	setAttr ".iog[0].og[0].gcl" -type "componentList" 1 "f[0:5]";
	setAttr ".vir" yes;
	setAttr ".vif" yes;
	setAttr ".uvst[0].uvsn" -type "string" "map1";
	setAttr -s 14 ".uvst[0].uvsp[0:13]" -type "float2" 0.375 0 0.625 0 0.375
		 0.25 0.625 0.25 0.375 0.5 0.625 0.5 0.375 0.75 0.625 0.75 0.375 1 0.625 1 0.875 0
		 0.875 0.25 0.125 0 0.125 0.25;
	setAttr ".cuvs" -type "string" "map1";
	setAttr ".dcc" -type "string" "Ambient+Diffuse";
	setAttr ".covm[0]"  0 1 1;
	setAttr ".cdvm[0]"  0 1 1;
	setAttr -s 8 ".vt[0:7]"  -50 -50 50 50 -50 50 -50 50 50 50 50 50 -50 50 -50
		 50 50 -50 -50 -50 -50 50 -50 -50;
	setAttr -s 12 ".ed[0:11]"  0 1 0 2 3 0 4 5 0 6 7 0 0 2 0 1 3 0 2 4 0
		 3 5 0 4 6 0 5 7 0 6 0 0 7 1 0;
	setAttr -s 6 -ch 24 ".fc[0:5]" -type "polyFaces" 
		f 4 0 5 -2 -5
		mu 0 4 0 1 3 2
		f 4 1 7 -3 -7
		mu 0 4 2 3 5 4
		f 4 2 9 -4 -9
		mu 0 4 4 5 7 6
		f 4 3 11 -1 -11
		mu 0 4 6 7 9 8
		f 4 -12 -10 -8 -6
		mu 0 4 1 10 11 3
		f 4 10 4 6 8
		mu 0 4 12 0 2 13;
	setAttr ".cd" -type "dataPolyComponent" Index_Data Edge 0 ;
	setAttr ".cvd" -type "dataPolyComponent" Index_Data Vertex 0 ;
	setAttr ".pd[0]" -type "dataPolyComponent" Index_Data UV 0 ;
	setAttr ".hfd" -type "dataPolyComponent" Index_Data Face 0 ;
createNode transform -n "pCube3";
	rename -uid "9D97958D-4663-5BF9-8EBA-E2A44369DDE4";
	setAttr ".t" -type "double3" 100 127.43496745398949 0 ;
	setAttr ".r" -type "double3" 0 0 -90 ;
	setAttr ".s" -type "double3" 0.14200163343932098 1.9151684265552191 0.044925402496336093 ;
createNode transform -n "transform3" -p "pCube3";
	rename -uid "29D22BAF-421F-040E-3257-6D808D83A045";
	setAttr ".v" no;
createNode mesh -n "pCubeShape3" -p "transform3";
	rename -uid "B2A97680-42A7-8347-5081-CCAC42055054";
	setAttr -k off ".v";
	setAttr ".io" yes;
	setAttr ".iog[0].og[0].gcl" -type "componentList" 1 "f[0:5]";
	setAttr ".vir" yes;
	setAttr ".vif" yes;
	setAttr ".uvst[0].uvsn" -type "string" "map1";
	setAttr -s 14 ".uvst[0].uvsp[0:13]" -type "float2" 0.375 0 0.625 0 0.375
		 0.25 0.625 0.25 0.375 0.5 0.625 0.5 0.375 0.75 0.625 0.75 0.375 1 0.625 1 0.875 0
		 0.875 0.25 0.125 0 0.125 0.25;
	setAttr ".cuvs" -type "string" "map1";
	setAttr ".dcc" -type "string" "Ambient+Diffuse";
	setAttr ".covm[0]"  0 1 1;
	setAttr ".cdvm[0]"  0 1 1;
	setAttr -s 8 ".vt[0:7]"  -50 -50 50 50 -50 50 -50 50 50 50 50 50 -50 50 -50
		 50 50 -50 -50 -50 -50 50 -50 -50;
	setAttr -s 12 ".ed[0:11]"  0 1 0 2 3 0 4 5 0 6 7 0 0 2 0 1 3 0 2 4 0
		 3 5 0 4 6 0 5 7 0 6 0 0 7 1 0;
	setAttr -s 6 -ch 24 ".fc[0:5]" -type "polyFaces" 
		f 4 0 5 -2 -5
		mu 0 4 0 1 3 2
		f 4 1 7 -3 -7
		mu 0 4 2 3 5 4
		f 4 2 9 -4 -9
		mu 0 4 4 5 7 6
		f 4 3 11 -1 -11
		mu 0 4 6 7 9 8
		f 4 -12 -10 -8 -6
		mu 0 4 1 10 11 3
		f 4 10 4 6 8
		mu 0 4 12 0 2 13;
	setAttr ".cd" -type "dataPolyComponent" Index_Data Edge 0 ;
	setAttr ".cvd" -type "dataPolyComponent" Index_Data Vertex 0 ;
	setAttr ".pd[0]" -type "dataPolyComponent" Index_Data UV 0 ;
	setAttr ".hfd" -type "dataPolyComponent" Index_Data Face 0 ;
createNode transform -n "pCube4";
	rename -uid "138D4595-487C-5EC8-2E29-69B84A3163BE";
	setAttr ".t" -type "double3" 100 79.821563914303766 0 ;
	setAttr ".r" -type "double3" 0 0 -90 ;
	setAttr ".s" -type "double3" 0.14200163343932098 1.9151684265552191 0.044925402496336093 ;
createNode transform -n "transform2" -p "pCube4";
	rename -uid "1667FCB9-45A9-2D56-E255-D2A5738B3EDA";
	setAttr ".v" no;
createNode mesh -n "pCubeShape4" -p "transform2";
	rename -uid "D355D911-4336-94E5-07AD-8081693B6451";
	setAttr -k off ".v";
	setAttr ".io" yes;
	setAttr ".iog[0].og[0].gcl" -type "componentList" 1 "f[0:5]";
	setAttr ".vir" yes;
	setAttr ".vif" yes;
	setAttr ".uvst[0].uvsn" -type "string" "map1";
	setAttr -s 14 ".uvst[0].uvsp[0:13]" -type "float2" 0.375 0 0.625 0 0.375
		 0.25 0.625 0.25 0.375 0.5 0.625 0.5 0.375 0.75 0.625 0.75 0.375 1 0.625 1 0.875 0
		 0.875 0.25 0.125 0 0.125 0.25;
	setAttr ".cuvs" -type "string" "map1";
	setAttr ".dcc" -type "string" "Ambient+Diffuse";
	setAttr ".covm[0]"  0 1 1;
	setAttr ".cdvm[0]"  0 1 1;
	setAttr -s 8 ".vt[0:7]"  -50 -50 50 50 -50 50 -50 50 50 50 50 50 -50 50 -50
		 50 50 -50 -50 -50 -50 50 -50 -50;
	setAttr -s 12 ".ed[0:11]"  0 1 0 2 3 0 4 5 0 6 7 0 0 2 0 1 3 0 2 4 0
		 3 5 0 4 6 0 5 7 0 6 0 0 7 1 0;
	setAttr -s 6 -ch 24 ".fc[0:5]" -type "polyFaces" 
		f 4 0 5 -2 -5
		mu 0 4 0 1 3 2
		f 4 1 7 -3 -7
		mu 0 4 2 3 5 4
		f 4 2 9 -4 -9
		mu 0 4 4 5 7 6
		f 4 3 11 -1 -11
		mu 0 4 6 7 9 8
		f 4 -12 -10 -8 -6
		mu 0 4 1 10 11 3
		f 4 10 4 6 8
		mu 0 4 12 0 2 13;
	setAttr ".cd" -type "dataPolyComponent" Index_Data Edge 0 ;
	setAttr ".cvd" -type "dataPolyComponent" Index_Data Vertex 0 ;
	setAttr ".pd[0]" -type "dataPolyComponent" Index_Data UV 0 ;
	setAttr ".hfd" -type "dataPolyComponent" Index_Data Face 0 ;
createNode transform -n "pCube5";
	rename -uid "BE4AF8FA-4FCB-8937-E51B-E4B60F049599";
	setAttr ".t" -type "double3" 100 32.958757848656703 0 ;
	setAttr ".r" -type "double3" 0 0 -90 ;
	setAttr ".s" -type "double3" 0.14200163343932098 1.9151684265552191 0.044925402496336093 ;
createNode transform -n "transform1" -p "pCube5";
	rename -uid "DEBD9E6D-4125-B43C-5C52-6BA7AD11ACF2";
	setAttr ".v" no;
createNode mesh -n "pCubeShape5" -p "transform1";
	rename -uid "0F051F9E-44CB-8D58-15EE-1597BF1EB988";
	setAttr -k off ".v";
	setAttr ".io" yes;
	setAttr ".iog[0].og[0].gcl" -type "componentList" 1 "f[0:5]";
	setAttr ".vir" yes;
	setAttr ".vif" yes;
	setAttr ".uvst[0].uvsn" -type "string" "map1";
	setAttr -s 14 ".uvst[0].uvsp[0:13]" -type "float2" 0.375 0 0.625 0 0.375
		 0.25 0.625 0.25 0.375 0.5 0.625 0.5 0.375 0.75 0.625 0.75 0.375 1 0.625 1 0.875 0
		 0.875 0.25 0.125 0 0.125 0.25;
	setAttr ".cuvs" -type "string" "map1";
	setAttr ".dcc" -type "string" "Ambient+Diffuse";
	setAttr ".covm[0]"  0 1 1;
	setAttr ".cdvm[0]"  0 1 1;
	setAttr -s 8 ".vt[0:7]"  -50 -50 50 50 -50 50 -50 50 50 50 50 50 -50 50 -50
		 50 50 -50 -50 -50 -50 50 -50 -50;
	setAttr -s 12 ".ed[0:11]"  0 1 0 2 3 0 4 5 0 6 7 0 0 2 0 1 3 0 2 4 0
		 3 5 0 4 6 0 5 7 0 6 0 0 7 1 0;
	setAttr -s 6 -ch 24 ".fc[0:5]" -type "polyFaces" 
		f 4 0 5 -2 -5
		mu 0 4 0 1 3 2
		f 4 1 7 -3 -7
		mu 0 4 2 3 5 4
		f 4 2 9 -4 -9
		mu 0 4 4 5 7 6
		f 4 3 11 -1 -11
		mu 0 4 6 7 9 8
		f 4 -12 -10 -8 -6
		mu 0 4 1 10 11 3
		f 4 10 4 6 8
		mu 0 4 12 0 2 13;
	setAttr ".cd" -type "dataPolyComponent" Index_Data Edge 0 ;
	setAttr ".cvd" -type "dataPolyComponent" Index_Data Vertex 0 ;
	setAttr ".pd[0]" -type "dataPolyComponent" Index_Data UV 0 ;
	setAttr ".hfd" -type "dataPolyComponent" Index_Data Face 0 ;
createNode transform -n "pCube6";
	rename -uid "2C882AE0-4CDD-5F66-F61B-8BA93DA5EA82";
	setAttr ".rp" -type "double3" 100.00000047683716 74.889736175537109 0 ;
	setAttr ".sp" -type "double3" 100.00000047683716 74.889736175537109 0 ;
createNode transform -n "polySurface1" -p "pCube6";
	rename -uid "8E8DA130-4C3E-B2EE-E89A-8893AAAFBCB0";
	setAttr ".t" -type "double3" -11.636524833429513 0 0 ;
	setAttr ".s" -type "double3" 0.11621380269514667 0.058149161504698489 0.058149161504698489 ;
	setAttr ".rp" -type "double3" 0 4.354775363915568 0 ;
	setAttr ".sp" -type "double3" 0 74.889736175537109 0 ;
	setAttr ".spt" -type "double3" 0 -70.534960811621545 0 ;
createNode transform -n "transform11" -p "|pCube6|polySurface1";
	rename -uid "8DC7BBDC-4EC3-B8D8-CBCE-019F0348F11C";
	setAttr ".v" no;
createNode mesh -n "polySurfaceShape1" -p "transform11";
	rename -uid "C366B207-46D1-726B-6A04-5FA972FA2F0F";
	setAttr -k off ".v";
	setAttr ".io" yes;
	setAttr -s 2 ".iog[0].og";
	setAttr ".vir" yes;
	setAttr ".vif" yes;
	setAttr ".uvst[0].uvsn" -type "string" "map1";
	setAttr ".cuvs" -type "string" "map1";
	setAttr ".dcc" -type "string" "Ambient+Diffuse";
	setAttr ".covm[0]"  0 1 1;
	setAttr ".cdvm[0]"  0 1 1;
createNode transform -n "polySurface2" -p "pCube6";
	rename -uid "0F463830-455A-5F57-B32A-A6991CF402A5";
	setAttr ".t" -type "double3" -11.636524833429513 0 0 ;
	setAttr ".s" -type "double3" 0.11621380269514667 0.058149161504698489 0.058149161504698489 ;
	setAttr ".rp" -type "double3" 23.242760539029305 4.354775363915568 0 ;
	setAttr ".sp" -type "double3" 200 74.889736175537109 0 ;
	setAttr ".spt" -type "double3" -176.75723946097068 -70.534960811621545 0 ;
createNode transform -n "transform7" -p "polySurface2";
	rename -uid "0E391A82-4C70-DF53-241E-B4AFA7ED201B";
	setAttr ".v" no;
createNode mesh -n "polySurfaceShape2" -p "transform7";
	rename -uid "057BBC93-47C0-1247-E09B-32A05BBA9362";
	setAttr -k off ".v";
	setAttr ".io" yes;
	setAttr -s 2 ".iog[0].og";
	setAttr ".vir" yes;
	setAttr ".vif" yes;
	setAttr ".uvst[0].uvsn" -type "string" "map1";
	setAttr ".cuvs" -type "string" "map1";
	setAttr ".dcc" -type "string" "Ambient+Diffuse";
	setAttr ".covm[0]"  0 1 1;
	setAttr ".cdvm[0]"  0 1 1;
createNode transform -n "polySurface3" -p "pCube6";
	rename -uid "702BC6E7-4B0D-087E-3D4D-7DB53817B3EA";
	setAttr ".t" -type "double3" -11.636524833429513 0 0 ;
	setAttr ".s" -type "double3" 0.11621380269514667 0.058149161504698489 0.058149161504698489 ;
	setAttr ".rp" -type "double3" 11.621380269514653 7.4102364798139462 0 ;
	setAttr ".sp" -type "double3" 100 127.43496704101562 0 ;
	setAttr ".spt" -type "double3" -88.37861973048534 -120.02473056120168 0 ;
createNode transform -n "transform10" -p "polySurface3";
	rename -uid "DA2088D2-4B21-AAB3-0DFD-9C841C048638";
	setAttr ".v" no;
createNode mesh -n "polySurfaceShape3" -p "transform10";
	rename -uid "659F9350-4FC4-8B53-84CE-A8A9FF1DD5A5";
	setAttr -k off ".v";
	setAttr ".io" yes;
	setAttr -s 2 ".iog[0].og";
	setAttr ".vir" yes;
	setAttr ".vif" yes;
	setAttr ".uvst[0].uvsn" -type "string" "map1";
	setAttr ".cuvs" -type "string" "map1";
	setAttr ".dcc" -type "string" "Ambient+Diffuse";
	setAttr ".covm[0]"  0 1 1;
	setAttr ".cdvm[0]"  0 1 1;
createNode transform -n "polySurface4" -p "pCube6";
	rename -uid "5E83AAB9-4355-E987-C8D9-0BBBDD4FE884";
	setAttr ".t" -type "double3" -11.636524833429513 0 0 ;
	setAttr ".s" -type "double3" 0.11621380269514667 0.058149161504698489 0.058149161504698489 ;
	setAttr ".rp" -type "double3" 11.621380269514653 4.6415570003527478 0 ;
	setAttr ".sp" -type "double3" 100 79.821563720703125 0 ;
	setAttr ".spt" -type "double3" -88.37861973048534 -75.180006720350377 0 ;
createNode transform -n "transform9" -p "polySurface4";
	rename -uid "8D8FD18A-481B-29EE-4ABC-F09335638A52";
	setAttr ".v" no;
createNode mesh -n "polySurfaceShape4" -p "transform9";
	rename -uid "F64D4D84-4745-F88B-E651-9B926B606176";
	setAttr -k off ".v";
	setAttr ".io" yes;
	setAttr -s 2 ".iog[0].og";
	setAttr ".vir" yes;
	setAttr ".vif" yes;
	setAttr ".uvst[0].uvsn" -type "string" "map1";
	setAttr ".cuvs" -type "string" "map1";
	setAttr ".dcc" -type "string" "Ambient+Diffuse";
	setAttr ".covm[0]"  0 1 1;
	setAttr ".cdvm[0]"  0 1 1;
createNode transform -n "polySurface5" -p "pCube6";
	rename -uid "0142F965-46FF-B53D-E7CC-6F85BC952505";
	setAttr ".t" -type "double3" -11.636524833429513 0 0 ;
	setAttr ".s" -type "double3" 0.11621380269514667 0.058149161504698489 0.058149161504698489 ;
	setAttr ".rp" -type "double3" 11.621380269514653 1.916524217987313 0 ;
	setAttr ".sp" -type "double3" 100 32.958759307861328 0 ;
	setAttr ".spt" -type "double3" -88.37861973048534 -31.042235089874016 0 ;
createNode transform -n "transform8" -p "polySurface5";
	rename -uid "5CFAA3AC-4A9E-C776-D947-CBB53950F182";
	setAttr ".v" no;
createNode mesh -n "polySurfaceShape5" -p "transform8";
	rename -uid "EDDD9B21-4BF8-7791-27E3-848D6C7BE9A7";
	setAttr -k off ".v";
	setAttr ".io" yes;
	setAttr -s 2 ".iog[0].og";
	setAttr ".vir" yes;
	setAttr ".vif" yes;
	setAttr ".uvst[0].uvsn" -type "string" "map1";
	setAttr ".cuvs" -type "string" "map1";
	setAttr ".dcc" -type "string" "Ambient+Diffuse";
	setAttr ".covm[0]"  0 1 1;
	setAttr ".cdvm[0]"  0 1 1;
createNode transform -n "transform6" -p "pCube6";
	rename -uid "A501D304-4DA8-35A7-52E3-B59176629F7B";
	setAttr ".v" no;
createNode mesh -n "pCube6Shape" -p "transform6";
	rename -uid "F1910021-4004-AADD-876E-3BB9E9B08CD9";
	setAttr -k off ".v";
	setAttr ".io" yes;
	setAttr -s 2 ".iog[0].og";
	setAttr ".vir" yes;
	setAttr ".vif" yes;
	setAttr ".uvst[0].uvsn" -type "string" "map1";
	setAttr ".cuvs" -type "string" "map1";
	setAttr ".dcc" -type "string" "Ambient+Diffuse";
	setAttr ".covm[0]"  0 1 1;
	setAttr ".cdvm[0]"  0 1 1;
createNode transform -n "polySurface1";
	rename -uid "2B0E2C45-45BE-BE15-633A-52ACFFA3108E";
createNode mesh -n "polySurface1Shape" -p "|polySurface1";
	rename -uid "B914395E-4D23-AA46-539C-D4B25CA5C82E";
	setAttr -k off ".v";
	setAttr -s 2 ".iog[0].og";
	setAttr ".vir" yes;
	setAttr ".vif" yes;
	setAttr ".uvst[0].uvsn" -type "string" "map1";
	setAttr ".cuvs" -type "string" "map1";
	setAttr ".dcc" -type "string" "Ambient+Diffuse";
	setAttr ".covm[0]"  0 1 1;
	setAttr ".cdvm[0]"  0 1 1;
createNode groupParts -n "groupParts8";
	rename -uid "7ECBEBB7-4265-43A2-F77F-1F88C7CBFD92";
	setAttr ".ihi" 0;
	setAttr ".ic" -type "componentList" 1 "f[0:29]";
createNode polyUnite -n "polyUnite2";
	rename -uid "6F2F0CAF-4FFC-CD53-7D86-9B8140FCA39B";
	setAttr -s 5 ".ip";
	setAttr -s 5 ".im";
createNode groupParts -n "groupParts3";
	rename -uid "99C29C5D-4287-5635-44B3-988AEA568064";
	setAttr ".ihi" 0;
	setAttr ".ic" -type "componentList" 6 "f[0]" "f[1]" "f[2]" "f[3]" "f[4]" "f[5]";
createNode polySeparate -n "polySeparate1";
	rename -uid "AC8A3A61-47D7-52F7-5357-C1BDA79FC994";
	setAttr ".ic" 5;
	setAttr -s 5 ".out";
createNode groupParts -n "groupParts2";
	rename -uid "6361EF00-4ED2-A120-DECE-D790D62A10AD";
	setAttr ".ihi" 0;
	setAttr ".ic" -type "componentList" 1 "f[0:29]";
createNode polyUnite -n "polyUnite1";
	rename -uid "1EE7DAC4-4E64-C0E1-2F51-18889D1CF1B2";
	setAttr -s 5 ".ip";
	setAttr -s 5 ".im";
createNode groupId -n "groupId1";
	rename -uid "40031DEB-49CF-C54D-8ED0-AFBA153C5D22";
	setAttr ".ihi" 0;
createNode groupParts -n "groupParts1";
	rename -uid "C257338F-4E0E-4066-1362-4CAF76F45275";
	setAttr ".ihi" 0;
	setAttr ".ic" -type "componentList" 1 "f[0:5]";
createNode polyCube -n "polyCube1";
	rename -uid "48440BD7-4262-EBDE-F9BA-49BAC19ABB3A";
	setAttr ".ax" -type "double3" 0 100 0 ;
	setAttr ".w" 100;
	setAttr ".h" 100;
	setAttr ".d" 100;
	setAttr ".cuv" 4;
createNode groupId -n "groupId2";
	rename -uid "292D307D-4C62-D550-24C4-C890B0603F82";
	setAttr ".ihi" 0;
createNode groupId -n "groupId3";
	rename -uid "93DA0E6E-4885-8FBF-E05B-DCAE9AF3382E";
	setAttr ".ihi" 0;
createNode groupId -n "groupId4";
	rename -uid "D2906F5B-4708-F79F-9EF2-33B310644AA8";
	setAttr ".ihi" 0;
createNode groupId -n "groupId5";
	rename -uid "DC2C72EB-4AEE-C3B7-01F0-1AA5009C033A";
	setAttr ".ihi" 0;
createNode groupId -n "groupId6";
	rename -uid "2548BA85-43DC-D3C4-13CC-42890690F9EE";
	setAttr ".ihi" 0;
createNode groupId -n "groupId7";
	rename -uid "F38476B4-4692-9643-37B0-7A80A885E414";
	setAttr ".ihi" 0;
createNode groupId -n "groupId8";
	rename -uid "9AA4E15F-44BC-64EF-4389-D79D81636BDE";
	setAttr ".ihi" 0;
createNode groupId -n "groupId9";
	rename -uid "D335ED5D-47AC-4BEB-1209-18BFCD8C9038";
	setAttr ".ihi" 0;
createNode groupId -n "groupId10";
	rename -uid "C158F6C8-46B3-1BA2-D025-D983B33D3FE1";
	setAttr ".ihi" 0;
createNode groupId -n "groupId11";
	rename -uid "178679F3-410A-F0BA-0A49-C99454955147";
	setAttr ".ihi" 0;
createNode groupId -n "groupId12";
	rename -uid "F645164E-4814-E55B-C886-C2AED30C8277";
	setAttr ".ihi" 0;
createNode groupParts -n "groupParts5";
	rename -uid "9FBED708-409B-C125-E3D2-F2BA0411556A";
	setAttr ".ihi" 0;
	setAttr ".ic" -type "componentList" 6 "f[0]" "f[1]" "f[2]" "f[3]" "f[4]" "f[5]";
createNode groupId -n "groupId14";
	rename -uid "3A46F476-4042-2073-6221-1F8E77CC9416";
	setAttr ".ihi" 0;
createNode groupParts -n "groupParts6";
	rename -uid "809841F9-4148-D3DA-7D2D-169890C6CDCB";
	setAttr ".ihi" 0;
	setAttr ".ic" -type "componentList" 6 "f[0]" "f[1]" "f[2]" "f[3]" "f[4]" "f[5]";
createNode groupId -n "groupId15";
	rename -uid "33DA733E-404D-9DB4-0129-FF8BB2AEAAA5";
	setAttr ".ihi" 0;
createNode groupParts -n "groupParts7";
	rename -uid "99632218-4296-9A12-01F4-B0A62BBCBE6D";
	setAttr ".ihi" 0;
	setAttr ".ic" -type "componentList" 6 "f[0]" "f[1]" "f[2]" "f[3]" "f[4]" "f[5]";
createNode groupId -n "groupId16";
	rename -uid "13A19976-4D52-9EB7-A545-D7960E32D20F";
	setAttr ".ihi" 0;
createNode groupParts -n "groupParts4";
	rename -uid "AD50C955-46CC-7B03-E6F9-9D980D5A09AA";
	setAttr ".ihi" 0;
	setAttr ".ic" -type "componentList" 6 "f[0]" "f[1]" "f[2]" "f[3]" "f[4]" "f[5]";
createNode groupId -n "groupId13";
	rename -uid "57D42053-4086-7D1C-0142-A58CC62A85E8";
	setAttr ".ihi" 0;
createNode groupId -n "groupId17";
	rename -uid "E4E756A2-4686-5ABB-4259-65B0BCD1FD01";
	setAttr ".ihi" 0;
select -ne :time1;
	setAttr ".o" 1;
	setAttr ".unw" 1;
select -ne :hardwareRenderingGlobals;
	setAttr ".otfna" -type "stringArray" 22 "NURBS Curves" "NURBS Surfaces" "Polygons" "Subdiv Surface" "Particles" "Particle Instance" "Fluids" "Strokes" "Image Planes" "UI" "Lights" "Cameras" "Locators" "Joints" "IK Handles" "Deformers" "Motion Trails" "Components" "Hair Systems" "Follicles" "Misc. UI" "Ornaments"  ;
	setAttr ".otfva" -type "Int32Array" 22 0 1 1 1 1 1
		 1 1 1 0 0 0 0 0 0 0 0 0
		 0 0 0 0 ;
	setAttr ".fprt" yes;
select -ne :renderPartition;
	setAttr -s 2 ".st";
select -ne :renderGlobalsList1;
select -ne :defaultShaderList1;
	setAttr -s 4 ".s";
select -ne :postProcessList1;
	setAttr -s 2 ".p";
select -ne :defaultRenderingList1;
select -ne :initialShadingGroup;
	setAttr -s 17 ".dsm";
	setAttr ".ro" yes;
	setAttr -s 17 ".gn";
select -ne :initialParticleSE;
	setAttr ".ro" yes;
select -ne :defaultResolution;
	setAttr ".pa" 1;
select -ne :hardwareRenderGlobals;
	setAttr ".ctrs" 256;
	setAttr ".btrs" 512;
select -ne :ikSystem;
	setAttr -s 4 ".sol";
connectAttr "groupId1.id" "pCubeShape1.iog.og[0].gid";
connectAttr ":initialShadingGroup.mwc" "pCubeShape1.iog.og[0].gco";
connectAttr "groupParts1.og" "pCubeShape1.i";
connectAttr "groupId2.id" "pCubeShape1.ciog.cog[0].cgid";
connectAttr "groupId3.id" "pCubeShape2.iog.og[0].gid";
connectAttr ":initialShadingGroup.mwc" "pCubeShape2.iog.og[0].gco";
connectAttr "groupId4.id" "pCubeShape2.ciog.cog[0].cgid";
connectAttr "groupId5.id" "pCubeShape3.iog.og[0].gid";
connectAttr ":initialShadingGroup.mwc" "pCubeShape3.iog.og[0].gco";
connectAttr "groupId6.id" "pCubeShape3.ciog.cog[0].cgid";
connectAttr "groupId7.id" "pCubeShape4.iog.og[0].gid";
connectAttr ":initialShadingGroup.mwc" "pCubeShape4.iog.og[0].gco";
connectAttr "groupId8.id" "pCubeShape4.ciog.cog[0].cgid";
connectAttr "groupId9.id" "pCubeShape5.iog.og[0].gid";
connectAttr ":initialShadingGroup.mwc" "pCubeShape5.iog.og[0].gco";
connectAttr "groupId10.id" "pCubeShape5.ciog.cog[0].cgid";
connectAttr "groupParts3.og" "polySurfaceShape1.i";
connectAttr "groupId12.id" "polySurfaceShape1.iog.og[0].gid";
connectAttr ":initialShadingGroup.mwc" "polySurfaceShape1.iog.og[0].gco";
connectAttr "groupParts4.og" "polySurfaceShape2.i";
connectAttr "groupId13.id" "polySurfaceShape2.iog.og[0].gid";
connectAttr ":initialShadingGroup.mwc" "polySurfaceShape2.iog.og[0].gco";
connectAttr "groupParts5.og" "polySurfaceShape3.i";
connectAttr "groupId14.id" "polySurfaceShape3.iog.og[0].gid";
connectAttr ":initialShadingGroup.mwc" "polySurfaceShape3.iog.og[0].gco";
connectAttr "groupParts6.og" "polySurfaceShape4.i";
connectAttr "groupId15.id" "polySurfaceShape4.iog.og[0].gid";
connectAttr ":initialShadingGroup.mwc" "polySurfaceShape4.iog.og[0].gco";
connectAttr "groupParts7.og" "polySurfaceShape5.i";
connectAttr "groupId16.id" "polySurfaceShape5.iog.og[0].gid";
connectAttr ":initialShadingGroup.mwc" "polySurfaceShape5.iog.og[0].gco";
connectAttr "groupParts2.og" "pCube6Shape.i";
connectAttr "groupId11.id" "pCube6Shape.iog.og[0].gid";
connectAttr ":initialShadingGroup.mwc" "pCube6Shape.iog.og[0].gco";
connectAttr "groupParts8.og" "polySurface1Shape.i";
connectAttr "groupId17.id" "polySurface1Shape.iog.og[0].gid";
connectAttr ":initialShadingGroup.mwc" "polySurface1Shape.iog.og[0].gco";
connectAttr "polyUnite2.out" "groupParts8.ig";
connectAttr "groupId17.id" "groupParts8.gi";
connectAttr "polySurfaceShape1.o" "polyUnite2.ip[0]";
connectAttr "polySurfaceShape3.o" "polyUnite2.ip[1]";
connectAttr "polySurfaceShape4.o" "polyUnite2.ip[2]";
connectAttr "polySurfaceShape5.o" "polyUnite2.ip[3]";
connectAttr "polySurfaceShape2.o" "polyUnite2.ip[4]";
connectAttr "polySurfaceShape1.wm" "polyUnite2.im[0]";
connectAttr "polySurfaceShape3.wm" "polyUnite2.im[1]";
connectAttr "polySurfaceShape4.wm" "polyUnite2.im[2]";
connectAttr "polySurfaceShape5.wm" "polyUnite2.im[3]";
connectAttr "polySurfaceShape2.wm" "polyUnite2.im[4]";
connectAttr "polySeparate1.out[0]" "groupParts3.ig";
connectAttr "groupId12.id" "groupParts3.gi";
connectAttr "pCube6Shape.o" "polySeparate1.ip";
connectAttr "polyUnite1.out" "groupParts2.ig";
connectAttr "groupId11.id" "groupParts2.gi";
connectAttr "pCubeShape1.o" "polyUnite1.ip[0]";
connectAttr "pCubeShape2.o" "polyUnite1.ip[1]";
connectAttr "pCubeShape3.o" "polyUnite1.ip[2]";
connectAttr "pCubeShape4.o" "polyUnite1.ip[3]";
connectAttr "pCubeShape5.o" "polyUnite1.ip[4]";
connectAttr "pCubeShape1.wm" "polyUnite1.im[0]";
connectAttr "pCubeShape2.wm" "polyUnite1.im[1]";
connectAttr "pCubeShape3.wm" "polyUnite1.im[2]";
connectAttr "pCubeShape4.wm" "polyUnite1.im[3]";
connectAttr "pCubeShape5.wm" "polyUnite1.im[4]";
connectAttr "polyCube1.out" "groupParts1.ig";
connectAttr "groupId1.id" "groupParts1.gi";
connectAttr "polySeparate1.out[2]" "groupParts5.ig";
connectAttr "groupId14.id" "groupParts5.gi";
connectAttr "polySeparate1.out[3]" "groupParts6.ig";
connectAttr "groupId15.id" "groupParts6.gi";
connectAttr "polySeparate1.out[4]" "groupParts7.ig";
connectAttr "groupId16.id" "groupParts7.gi";
connectAttr "polySeparate1.out[1]" "groupParts4.ig";
connectAttr "groupId13.id" "groupParts4.gi";
connectAttr "pCubeShape1.iog.og[0]" ":initialShadingGroup.dsm" -na;
connectAttr "pCubeShape1.ciog.cog[0]" ":initialShadingGroup.dsm" -na;
connectAttr "pCubeShape2.iog.og[0]" ":initialShadingGroup.dsm" -na;
connectAttr "pCubeShape2.ciog.cog[0]" ":initialShadingGroup.dsm" -na;
connectAttr "pCubeShape3.iog.og[0]" ":initialShadingGroup.dsm" -na;
connectAttr "pCubeShape3.ciog.cog[0]" ":initialShadingGroup.dsm" -na;
connectAttr "pCubeShape4.iog.og[0]" ":initialShadingGroup.dsm" -na;
connectAttr "pCubeShape4.ciog.cog[0]" ":initialShadingGroup.dsm" -na;
connectAttr "pCubeShape5.iog.og[0]" ":initialShadingGroup.dsm" -na;
connectAttr "pCubeShape5.ciog.cog[0]" ":initialShadingGroup.dsm" -na;
connectAttr "pCube6Shape.iog.og[0]" ":initialShadingGroup.dsm" -na;
connectAttr "polySurfaceShape1.iog.og[0]" ":initialShadingGroup.dsm" -na;
connectAttr "polySurfaceShape2.iog.og[0]" ":initialShadingGroup.dsm" -na;
connectAttr "polySurfaceShape3.iog.og[0]" ":initialShadingGroup.dsm" -na;
connectAttr "polySurfaceShape4.iog.og[0]" ":initialShadingGroup.dsm" -na;
connectAttr "polySurfaceShape5.iog.og[0]" ":initialShadingGroup.dsm" -na;
connectAttr "polySurface1Shape.iog.og[0]" ":initialShadingGroup.dsm" -na;
connectAttr "groupId1.msg" ":initialShadingGroup.gn" -na;
connectAttr "groupId2.msg" ":initialShadingGroup.gn" -na;
connectAttr "groupId3.msg" ":initialShadingGroup.gn" -na;
connectAttr "groupId4.msg" ":initialShadingGroup.gn" -na;
connectAttr "groupId5.msg" ":initialShadingGroup.gn" -na;
connectAttr "groupId6.msg" ":initialShadingGroup.gn" -na;
connectAttr "groupId7.msg" ":initialShadingGroup.gn" -na;
connectAttr "groupId8.msg" ":initialShadingGroup.gn" -na;
connectAttr "groupId9.msg" ":initialShadingGroup.gn" -na;
connectAttr "groupId10.msg" ":initialShadingGroup.gn" -na;
connectAttr "groupId11.msg" ":initialShadingGroup.gn" -na;
connectAttr "groupId12.msg" ":initialShadingGroup.gn" -na;
connectAttr "groupId13.msg" ":initialShadingGroup.gn" -na;
connectAttr "groupId14.msg" ":initialShadingGroup.gn" -na;
connectAttr "groupId15.msg" ":initialShadingGroup.gn" -na;
connectAttr "groupId16.msg" ":initialShadingGroup.gn" -na;
connectAttr "groupId17.msg" ":initialShadingGroup.gn" -na;
// End of Fence.ma
