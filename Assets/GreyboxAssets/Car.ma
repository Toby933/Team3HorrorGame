//Maya ASCII 2016 scene
//Name: Car.ma
//Last modified: Mon, Oct 10, 2016 02:44:28 PM
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
	rename -uid "EBEC9AF8-4A28-A7E6-582B-27BCD98631BA";
	setAttr ".t" -type "double3" 0 44 0 ;
	setAttr ".rp" -type "double3" 0 -40 0 ;
	setAttr ".sp" -type "double3" 0 -40 0 ;
createNode mesh -n "pCubeShape1" -p "pCube1";
	rename -uid "1A61E806-4106-7985-6394-E7B6D1266C3A";
	setAttr -k off ".v";
	setAttr ".vir" yes;
	setAttr ".vif" yes;
	setAttr ".pv" -type "double2" 0.5 0.49999997019767761 ;
	setAttr ".uvst[0].uvsn" -type "string" "map1";
	setAttr -s 44 ".uvst[0].uvsp[0:43]" -type "float2" 0.375 0 0.625 0 0.375
		 0.25 0.625 0.25 0.375 0.33333334 0.625 0.33333334 0.375 0.41666669 0.625 0.41666669
		 0.375 0.5 0.625 0.5 0.375 0.75 0.625 0.75 0.375 0.83333331 0.625 0.83333331 0.375
		 0.91666663 0.625 0.91666663 0.375 0.99999994 0.625 0.99999994 0.875 0 0.79166669
		 0 0.70833337 0 0.875 0.25 0.79166669 0.25 0.70833337 0.25 0.125 0 0.20833334 0 0.29166669
		 0 0.125 0.25 0.20833334 0.25 0.29166669 0.25 0.625 0.17104015 0.375 0.17104015 0.29166669
		 0.17104015 0.20833334 0.17104015 0.125 0.17104015 0.375 0.57895982 0.625 0.57895982
		 0.875 0.17104015 0.79166675 0.17104015 0.70833337 0.17104015 0.375 0.33333334 0.625
		 0.33333334 0.625 0.41666669 0.375 0.41666669;
	setAttr ".cuvs" -type "string" "map1";
	setAttr ".dcc" -type "string" "Ambient+Diffuse";
	setAttr ".covm[0]"  0 1 1;
	setAttr ".cdvm[0]"  0 1 1;
	setAttr -s 28 ".pt[0:27]" -type "float3"  10.675148 13.195518 0 -10.675148 
		13.195518 0 9.7197914 -5.7888727 -23.164837 -9.7197914 -5.7888727 -23.164837 9.7197914 
		-5.7888727 0 -9.7197914 -5.7888727 0 9.7197914 -5.7888727 -6.5682497 -9.7197914 -5.7888727 
		-6.5682497 9.7197914 -5.7888727 9.1624956 -9.7197914 -5.7888727 9.1624956 10.675148 
		13.195518 0 -10.675148 13.195518 0 10.675148 13.195518 -6.5682497 -10.675148 13.195518 
		-6.5682497 10.675148 13.195518 0 -10.675148 13.195518 0 -10.675148 0.20714572 0 10.675148 
		0.20714572 0 10.675148 0.20714572 0 10.675148 0.20714572 -6.5682497 10.675148 0.20714572 
		0 -10.675148 0.20714572 0 -10.675148 0.20714572 -6.5682497 -10.675148 0.20714572 
		0 9.7197914 25.82295 -32.271866 -9.7197914 25.82295 -32.271866 -9.7197914 25.82295 
		11.754134 9.7197914 25.82295 11.754134;
	setAttr -s 28 ".vt[0:27]"  -80 -40 150 80 -40 150 -72.8405304 40 150
		 72.8405304 40 150 -72.8405304 40 71.69792938 72.8405304 40 71.69792938 -72.8405304 40 -91.6111145
		 72.8405304 40 -91.6111145 -72.8405304 40 -150 72.8405304 40 -150 -80 -40 -150 80 -40 -150
		 -80 -40 -91.6111145 80 -40 -91.6111145 -80 -40 71.69792938 80 -40 71.69792938 80 14.73284912 150
		 -80 14.73284912 150 -80 14.73284912 71.69792938 -80 14.73284912 -91.6111145 -80 14.73284912 -150
		 80 14.73284912 -150 80 14.73284912 -91.6111145 80 14.73284912 71.69792938 -72.8405304 40 71.69792938
		 72.8405304 40 71.69792938 72.8405304 40 -91.6111145 -72.8405304 40 -91.6111145;
	setAttr -s 52 ".ed[0:51]"  0 1 0 2 3 0 4 5 0 6 7 0 8 9 0 10 11 0 12 13 1
		 14 15 1 0 17 0 1 16 0 2 4 0 3 5 0 4 6 0 5 7 0 6 8 0 7 9 0 8 20 0 9 21 0 10 12 0 11 13 0
		 12 14 0 13 15 0 14 0 0 15 1 0 13 22 1 15 23 1 12 19 1 14 18 1 16 3 0 17 2 0 16 17 1
		 18 4 1 17 18 1 19 6 1 18 19 1 20 10 0 19 20 1 21 11 0 20 21 1 22 7 1 21 22 1 23 5 1
		 22 23 1 23 16 1 4 24 0 5 25 0 24 25 0 7 26 0 25 26 0 6 27 0 27 26 0 24 27 0;
	setAttr -s 26 -ch 104 ".fc[0:25]" -type "polyFaces" 
		f 4 0 9 30 -9
		mu 0 4 0 1 30 31
		f 4 1 11 -3 -11
		mu 0 4 2 3 5 4
		f 4 46 48 -51 -52
		mu 0 4 40 41 42 43
		f 4 3 15 -5 -15
		mu 0 4 6 7 9 8
		f 4 38 37 -6 -36
		mu 0 4 35 36 11 10
		f 4 5 19 -7 -19
		mu 0 4 10 11 13 12
		f 4 6 21 -8 -21
		mu 0 4 12 13 15 14
		f 4 7 23 -1 -23
		mu 0 4 14 15 17 16
		f 4 -20 -38 40 -25
		mu 0 4 19 18 37 38
		f 4 -22 24 42 -26
		mu 0 4 20 19 38 39
		f 4 -24 25 43 -10
		mu 0 4 1 20 39 30
		f 4 18 26 36 35
		mu 0 4 24 25 33 34
		f 4 20 27 34 -27
		mu 0 4 25 26 32 33
		f 4 22 8 32 -28
		mu 0 4 26 0 31 32
		f 4 -31 28 -2 -30
		mu 0 4 31 30 3 2
		f 4 -33 29 10 -32
		mu 0 4 32 31 2 29
		f 4 -35 31 12 -34
		mu 0 4 33 32 29 28
		f 4 -37 33 14 16
		mu 0 4 34 33 28 27
		f 4 4 17 -39 -17
		mu 0 4 8 9 36 35
		f 4 -41 -18 -16 -40
		mu 0 4 38 37 21 22
		f 4 -43 39 -14 -42
		mu 0 4 39 38 22 23
		f 4 -44 41 -12 -29
		mu 0 4 30 39 23 3
		f 4 2 45 -47 -45
		mu 0 4 4 5 41 40
		f 4 13 47 -49 -46
		mu 0 4 5 7 42 41
		f 4 -4 49 50 -48
		mu 0 4 7 6 43 42
		f 4 -13 44 51 -50
		mu 0 4 6 4 40 43;
	setAttr ".cd" -type "dataPolyComponent" Index_Data Edge 0 ;
	setAttr ".cvd" -type "dataPolyComponent" Index_Data Vertex 0 ;
	setAttr ".pd[0]" -type "dataPolyComponent" Index_Data UV 0 ;
	setAttr ".hfd" -type "dataPolyComponent" Index_Data Face 0 ;
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
	setAttr -s 2 ".dsm";
	setAttr ".ro" yes;
select -ne :initialParticleSE;
	setAttr ".ro" yes;
select -ne :defaultResolution;
	setAttr ".pa" 1;
select -ne :hardwareRenderGlobals;
	setAttr ".ctrs" 256;
	setAttr ".btrs" 512;
select -ne :ikSystem;
	setAttr -s 4 ".sol";
connectAttr "pCubeShape1.iog" ":initialShadingGroup.dsm" -na;
// End of Car.ma
