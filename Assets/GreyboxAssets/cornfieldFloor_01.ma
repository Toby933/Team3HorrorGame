//Maya ASCII 2016 scene
//Name: cornfieldFloor_01.ma
//Last modified: Mon, Oct 10, 2016 12:13:31 PM
//Codeset: 1252
requires maya "2016";
currentUnit -l centimeter -a degree -t film;
fileInfo "application" "maya";
fileInfo "product" "Maya 2016";
fileInfo "version" "2016";
fileInfo "cutIdentifier" "201511301000-979500";
fileInfo "osv" "Microsoft Windows 7 Enterprise Edition, 64-bit Windows 7 Service Pack 1 (Build 7601)\n";
fileInfo "license" "education";
createNode transform -n "pPlane2";
	rename -uid "8B8A0051-473A-9A96-16C4-1F8AD0BA10EE";
	setAttr ".s" -type "double3" 23.016474328423431 23.016474328423431 23.016474328423431 ;
createNode mesh -n "pPlaneShape2" -p "pPlane2";
	rename -uid "E02E108C-4B39-A1E3-9F6A-CCBC4D431654";
	setAttr -k off ".v";
	setAttr ".vir" yes;
	setAttr ".vif" yes;
	setAttr ".pv" -type "double2" 0.5 0.5 ;
	setAttr ".uvst[0].uvsn" -type "string" "map1";
	setAttr ".cuvs" -type "string" "map1";
	setAttr ".dcc" -type "string" "Ambient+Diffuse";
	setAttr ".covm[0]"  0 1 1;
	setAttr ".cdvm[0]"  0 1 1;
	setAttr -s 100 ".pt[0:99]" -type "float3"  0 -6.7055225e-008 0 0 -0.014605351 
		0 0 -0.014605351 0 0 -6.7055225e-008 0 0 -0.014605351 0 0 -0.014605351 0 0 -6.7055225e-008 
		0 0 -0.014605351 0 0 -0.014605351 0 0 -6.7055225e-008 0 0 -0.014605351 0 0 -0.014605351 
		0 0 -6.7055225e-008 0 0 -0.014605351 0 0 -0.014605351 0 0 -6.7055225e-008 0 0 -0.014605351 
		0 0 -0.014605351 0 0 -6.7055225e-008 0 0 -0.014605351 0 0 -0.014605351 0 0 -6.7055225e-008 
		0 0 -0.014605351 0 0 -0.014605351 0 0 -6.7055225e-008 0 0 -6.7055225e-008 0 0 -0.014605351 
		0 0 -0.014605351 0 0 -6.7055225e-008 0 0 -0.014605351 0 0 -0.014605351 0 0 -6.7055225e-008 
		0 0 -0.014605351 0 0 -0.014605351 0 0 -6.7055225e-008 0 0 -0.014605351 0 0 -0.014605351 
		0 0 -6.7055225e-008 0 0 -0.014605351 0 0 -0.014605351 0 0 -6.7055225e-008 0 0 -0.014605351 
		0 0 -0.014605351 0 0 -6.7055225e-008 0 0 -0.014605351 0 0 -0.014605351 0 0 -6.7055225e-008 
		0 0 -0.014605351 0 0 -0.014605351 0 0 -6.7055225e-008 0 0 -6.7055225e-008 -0.27314827 
		0 0 -0.27314827 0 0 -0.27314827 0 0 -0.27314827 0 0 -0.27314827 0 0 -0.27314827 0 
		0 -0.27314827 0 0 -0.27314827 0 0 -0.27314827 0 0 -0.27314827 0 0 -0.27314827 0 0 
		-0.27314827 0 0 -0.27314827 0 0 -0.27314827 0 0 -0.27314827 0 0 -0.27314827 0 0 -0.27314827 
		0 0 -0.27314827 0 0 -0.27314827 0 0 -0.27314827 0 0 -0.27314827 0 0 -0.27314827 0 
		0 -0.27314827 0 0 -0.27314827 0 -6.7055225e-008 -0.27314827 0 -6.7055225e-008 0.27314827 
		0 0 0.27314827 0 0 0.27314827 0 0 0.27314827 0 0 0.27314827 0 0 0.27314827 0 0 0.27314827 
		0 0 0.27314827 0 0 0.27314827 0 0 0.27314827 0 0 0.27314827 0 0 0.27314827 0 0 0.27314827 
		0 0 0.27314827 0 0 0.27314827 0 0 0.27314827 0 0 0.27314827 0 0 0.27314827 0 0 0.27314827 
		0 0 0.27314827 0 0 0.27314827 0 0 0.27314827 0 0 0.27314827 0 0 0.27314827 0 -6.7055225e-008 
		0.27314827;
	setAttr ".dr" 1;
createNode polySplitRing -n "polySplitRing2";
	rename -uid "DF09EDA5-4A6C-BC61-8247-E598C748C94C";
	setAttr ".uopa" yes;
	setAttr ".ics" -type "componentList" 24 "e[1]" "e[3]" "e[5]" "e[7]" "e[9]" "e[11]" "e[13]" "e[15]" "e[17]" "e[19]" "e[21]" "e[23]" "e[25]" "e[27]" "e[29]" "e[31]" "e[33]" "e[35]" "e[37]" "e[39]" "e[41]" "e[43]" "e[45]" "e[47:48]";
	setAttr ".ix" -type "matrix" 23.016474328423431 0 0 0 0 23.016474328423431 0 0 0 0 23.016474328423431 0
		 0 0 0 1;
	setAttr ".wt" 0.91533297300338745;
	setAttr ".dr" no;
	setAttr ".re" 19;
	setAttr ".sma" 29.999999999999996;
	setAttr ".stp" 2;
	setAttr ".p[0]"  0 0 1;
	setAttr ".fq" yes;
createNode polyCrease -n "polyCrease1";
	rename -uid "B465716E-4694-D0AD-3F7F-E29E37EF3BCC";
	setAttr ".uopa" yes;
	setAttr ".ics" -type "componentList" 9 "e[1]" "e[7]" "e[13]" "e[19]" "e[25]" "e[31]" "e[37]" "e[43]" "e[48]";
	setAttr -s 9 ".cr";
	setAttr ".cr[1]" 10;
	setAttr ".cr[7]" 10;
	setAttr ".cr[13]" 10;
	setAttr ".cr[19]" 10;
	setAttr ".cr[25]" 10;
	setAttr ".cr[31]" 10;
	setAttr ".cr[37]" 10;
	setAttr ".cr[43]" 10;
	setAttr ".cr[48]" 10;
createNode polyMergeVert -n "polyMergeVert1";
	rename -uid "DAC1EE67-47AF-71D1-9C46-D8BDD8AEC8AF";
	setAttr ".ics" -type "componentList" 1 "vtx[0:49]";
	setAttr ".ix" -type "matrix" 23.016474328423431 0 0 0 0 23.016474328423431 0 0 0 0 23.016474328423431 0
		 0 0 0 1;
	setAttr ".am" yes;
createNode polyTweak -n "polyTweak1";
	rename -uid "0EBEF4C6-4C43-A60C-A2CB-71AE41CBAB29";
	setAttr ".uopa" yes;
	setAttr -s 33 ".tk";
	setAttr ".tk[1]" -type "float3" 0 0.014605424 0 ;
	setAttr ".tk[2]" -type "float3" 0 0.014605424 0 ;
	setAttr ".tk[4]" -type "float3" 0 0.014605424 0 ;
	setAttr ".tk[5]" -type "float3" 0 0.014605424 0 ;
	setAttr ".tk[7]" -type "float3" 0 0.014605424 0 ;
	setAttr ".tk[8]" -type "float3" 0 0.014605424 0 ;
	setAttr ".tk[10]" -type "float3" 0 0.014605424 0 ;
	setAttr ".tk[11]" -type "float3" 0 0.014605424 0 ;
	setAttr ".tk[13]" -type "float3" 0 0.014605424 0 ;
	setAttr ".tk[14]" -type "float3" 0 0.014605424 0 ;
	setAttr ".tk[16]" -type "float3" 0 0.014605424 0 ;
	setAttr ".tk[17]" -type "float3" 0 0.014605424 0 ;
	setAttr ".tk[19]" -type "float3" 0 0.014605424 0 ;
	setAttr ".tk[20]" -type "float3" 0 0.014605424 0 ;
	setAttr ".tk[22]" -type "float3" 0 0.014605424 0 ;
	setAttr ".tk[23]" -type "float3" 0 0.014605424 0 ;
	setAttr ".tk[26]" -type "float3" 0 0.014605424 0 ;
	setAttr ".tk[27]" -type "float3" 0 0.014605424 0 ;
	setAttr ".tk[29]" -type "float3" 0 0.014605424 0 ;
	setAttr ".tk[30]" -type "float3" 0 0.014605424 0 ;
	setAttr ".tk[32]" -type "float3" 0 0.014605424 0 ;
	setAttr ".tk[33]" -type "float3" 0 0.014605424 0 ;
	setAttr ".tk[35]" -type "float3" 0 0.014605424 0 ;
	setAttr ".tk[36]" -type "float3" 0 0.014605424 0 ;
	setAttr ".tk[38]" -type "float3" 0 0.014605424 0 ;
	setAttr ".tk[39]" -type "float3" 0 0.014605424 0 ;
	setAttr ".tk[41]" -type "float3" 0 0.014605424 0 ;
	setAttr ".tk[42]" -type "float3" 0 0.014605424 0 ;
	setAttr ".tk[44]" -type "float3" 0 0.014605424 0 ;
	setAttr ".tk[45]" -type "float3" 0 0.014605424 0 ;
	setAttr ".tk[47]" -type "float3" 0 0.014605424 0 ;
	setAttr ".tk[48]" -type "float3" 0 0.014605424 0 ;
createNode polyPlane -n "polyPlane2";
	rename -uid "F3A7CAEE-4935-7F42-8BB0-EF80D9731B9C";
	setAttr ".sw" 24;
	setAttr ".sh" 1;
	setAttr ".cuv" 2;
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
	setAttr -s 3 ".dsm";
	setAttr ".ro" yes;
select -ne :initialParticleSE;
	setAttr ".ro" yes;
select -ne :defaultResolution;
	setAttr ".pa" 1;
select -ne :hardwareRenderGlobals;
	setAttr ".ctrs" 256;
	setAttr ".btrs" 512;
connectAttr "polySplitRing2.out" "pPlaneShape2.i";
connectAttr "polyCrease1.out" "polySplitRing2.ip";
connectAttr "pPlaneShape2.wm" "polySplitRing2.mp";
connectAttr "polyMergeVert1.out" "polyCrease1.ip";
connectAttr "polyTweak1.out" "polyMergeVert1.ip";
connectAttr "pPlaneShape2.wm" "polyMergeVert1.mp";
connectAttr "polyPlane2.out" "polyTweak1.ip";
connectAttr "pPlaneShape2.iog" ":initialShadingGroup.dsm" -na;
// End of cornfieldFloor_01.ma
