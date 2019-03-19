//Maya ASCII 2018 scene
//Name: Environment.ma
//Last modified: Wed, Mar 06, 2019 04:09:00 PM
//Codeset: 1252
requires maya "2018";
currentUnit -l meter -a degree -t film;
fileInfo "application" "maya";
fileInfo "product" "Maya 2018";
fileInfo "version" "2018";
fileInfo "cutIdentifier" "201706261615-f9658c4cfc";
fileInfo "osv" "Microsoft Windows 8 , 64-bit  (Build 9200)\n";
fileInfo "license" "education";
createNode transform -s -n "persp";
	rename -uid "28775EBC-41F1-488F-8498-7DBD79814423";
	setAttr ".v" no;
	setAttr ".t" -type "double3" 1.3565842400303154 3.1764420736747923 8.5504926193209414 ;
	setAttr ".r" -type "double3" -17.738352729223354 352.19999999958179 2.0064103041302381e-16 ;
createNode camera -s -n "perspShape" -p "persp";
	rename -uid "C4213FEB-470C-C804-25CF-ACA55C2E45E0";
	setAttr -k off ".v" no;
	setAttr ".fl" 34.999999999999993;
	setAttr ".ncp" 0.001;
	setAttr ".fcp" 100;
	setAttr ".fd" 0.05;
	setAttr ".coi" 17.673305718447587;
	setAttr ".ow" 0.1;
	setAttr ".imn" -type "string" "persp";
	setAttr ".den" -type "string" "persp_depth";
	setAttr ".man" -type "string" "persp_mask";
	setAttr ".hc" -type "string" "viewSet -p %camera";
	setAttr ".ai_translator" -type "string" "perspective";
createNode transform -s -n "top";
	rename -uid "D423B885-4903-E26E-2720-358AB223DB72";
	setAttr ".v" no;
	setAttr ".t" -type "double3" 0 10.001000000000001 0 ;
	setAttr ".r" -type "double3" -89.999999999999986 0 0 ;
createNode camera -s -n "topShape" -p "top";
	rename -uid "DF5E4A96-49FA-9E26-7519-A3A59E33C809";
	setAttr -k off ".v" no;
	setAttr ".rnd" no;
	setAttr ".ncp" 0.001;
	setAttr ".fcp" 100;
	setAttr ".fd" 0.05;
	setAttr ".coi" 10.001000000000001;
	setAttr ".ow" 0.3;
	setAttr ".imn" -type "string" "top";
	setAttr ".den" -type "string" "top_depth";
	setAttr ".man" -type "string" "top_mask";
	setAttr ".hc" -type "string" "viewSet -t %camera";
	setAttr ".o" yes;
	setAttr ".ai_translator" -type "string" "orthographic";
createNode transform -s -n "front";
	rename -uid "71EF7091-4F43-9B27-DB20-8894446C544B";
	setAttr ".v" no;
	setAttr ".t" -type "double3" 0 0 10.001000000000001 ;
createNode camera -s -n "frontShape" -p "front";
	rename -uid "02363DBD-4D1C-7A26-6083-F5B00BD41B2A";
	setAttr -k off ".v" no;
	setAttr ".rnd" no;
	setAttr ".ncp" 0.001;
	setAttr ".fcp" 100;
	setAttr ".fd" 0.05;
	setAttr ".coi" 10.001000000000001;
	setAttr ".ow" 0.3;
	setAttr ".imn" -type "string" "front";
	setAttr ".den" -type "string" "front_depth";
	setAttr ".man" -type "string" "front_mask";
	setAttr ".hc" -type "string" "viewSet -f %camera";
	setAttr ".o" yes;
	setAttr ".ai_translator" -type "string" "orthographic";
createNode transform -s -n "side";
	rename -uid "1C7D4EB8-4A57-A8E9-0234-0EB3E86AEC97";
	setAttr ".v" no;
	setAttr ".t" -type "double3" 10.001000000000001 0 0 ;
	setAttr ".r" -type "double3" 0 89.999999999999986 0 ;
createNode camera -s -n "sideShape" -p "side";
	rename -uid "DCF1B8EB-4EC0-5A3E-94FB-1A9EBC7E6123";
	setAttr -k off ".v" no;
	setAttr ".rnd" no;
	setAttr ".ncp" 0.001;
	setAttr ".fcp" 100;
	setAttr ".fd" 0.05;
	setAttr ".coi" 10.001000000000001;
	setAttr ".ow" 0.3;
	setAttr ".imn" -type "string" "side";
	setAttr ".den" -type "string" "side_depth";
	setAttr ".man" -type "string" "side_mask";
	setAttr ".hc" -type "string" "viewSet -s %camera";
	setAttr ".o" yes;
	setAttr ".ai_translator" -type "string" "orthographic";
createNode transform -n "pCube1";
	rename -uid "637948EE-4AE1-3641-1A04-83B4FC3E2DC9";
	setAttr ".t" -type "double3" 0 -0.28027945869523829 0 ;
	setAttr ".s" -type "double3" 2947.7880077922136 64.751470315297624 2709.2401659373472 ;
createNode mesh -n "pCubeShape1" -p "pCube1";
	rename -uid "9AD72CE3-4E87-318D-CC35-DFB20C31412B";
	setAttr -k off ".v";
	setAttr ".vir" yes;
	setAttr ".vif" yes;
	setAttr ".pv" -type "double2" 0.41197624802589417 0.36724720895290375 ;
	setAttr ".uvst[0].uvsn" -type "string" "map1";
	setAttr ".cuvs" -type "string" "map1";
	setAttr ".dcc" -type "string" "Ambient+Diffuse";
	setAttr ".covm[0]"  0 1 1;
	setAttr ".cdvm[0]"  0 1 1;
	setAttr -s 10 ".pt";
	setAttr ".pt[53]" -type "float3" 0 0 0.00030361963 ;
	setAttr ".pt[54]" -type "float3" 3.7922018e-05 -0.0014993425 -0.00015979668 ;
	setAttr ".pt[285]" -type "float3" 0 0 9.1469752e-05 ;
	setAttr ".pt[316]" -type "float3" 0 0 5.5251559e-05 ;
	setAttr ".pt[317]" -type "float3" 0 0 -0.0001403166 ;
	setAttr ".pt[347]" -type "float3" 0 0 0.00016705193 ;
	setAttr ".pt[378]" -type "float3" 0 0 0.00022009213 ;
	setAttr ".pt[381]" -type "float3" 3.7922018e-05 -0.0014993425 -0.00015979668 ;
	setAttr ".ai_translator" -type "string" "polymesh";
createNode lightLinker -s -n "lightLinker1";
	rename -uid "DC914C7A-4D9E-B51C-F423-2AB2DCEB9C8A";
	setAttr -s 2 ".lnk";
	setAttr -s 2 ".slnk";
createNode shapeEditorManager -n "shapeEditorManager";
	rename -uid "40E73073-4817-0828-E683-7489CFF6E2BD";
createNode poseInterpolatorManager -n "poseInterpolatorManager";
	rename -uid "12C73984-4FC1-7337-7659-7DAE25ABE686";
createNode displayLayerManager -n "layerManager";
	rename -uid "5DBFDCAA-4EAF-29F4-CD5A-90A2979103EE";
createNode displayLayer -n "defaultLayer";
	rename -uid "3F23741D-445F-FC16-C031-20A982E9602B";
createNode renderLayerManager -n "renderLayerManager";
	rename -uid "22E874D6-40C6-CA3E-7923-CA975C34D30E";
createNode renderLayer -n "defaultRenderLayer";
	rename -uid "79BF6A56-4816-463F-A53A-07A42B13F8E6";
	setAttr ".g" yes;
createNode polyCube -n "polyCube1";
	rename -uid "111C4953-4D86-B323-B251-9BAE1DCF80A7";
	setAttr ".cuv" 4;
createNode polySplit -n "polySplit1";
	rename -uid "BC7D3915-4DCC-F0A7-7204-0DBEC84200FA";
	setAttr -s 5 ".e[0:4]"  0.090161197 0.090161197 0.090161197 0.090161197
		 0.090161197;
	setAttr -s 5 ".d[0:4]"  -2147483648 -2147483645 -2147483646 -2147483647 -2147483648;
	setAttr ".sma" 180;
	setAttr ".m2015" yes;
createNode polySplit -n "polySplit2";
	rename -uid "E7EF7FFE-466C-75E2-874A-1CBE6133DF25";
	setAttr -s 5 ".e[0:4]"  0.91894799 0.91894799 0.91894799 0.91894799
		 0.91894799;
	setAttr -s 5 ".d[0:4]"  -2147483636 -2147483633 -2147483634 -2147483635 -2147483636;
	setAttr ".sma" 180;
	setAttr ".m2015" yes;
createNode polySplit -n "polySplit3";
	rename -uid "5B34D33A-48FE-B2AF-677A-BCAC17417E95";
	setAttr -s 9 ".e[0:8]"  0.908831 0.091169 0.908831 0.908831 0.091169
		 0.091169 0.908831 0.091169 0.908831;
	setAttr -s 9 ".d[0:8]"  -2147483642 -2147483630 -2147483623 -2147483641 -2147483637 -2147483621 
		-2147483632 -2147483638 -2147483642;
	setAttr ".sma" 180;
	setAttr ".m2015" yes;
createNode polySplit -n "polySplit4";
	rename -uid "95CBF9E4-4730-CC27-5C5E-E7A7C725FF29";
	setAttr -s 9 ".e[0:8]"  0.742293 0.257707 0.742293 0.742293 0.257707
		 0.257707 0.742293 0.257707 0.742293;
	setAttr -s 9 ".d[0:8]"  -2147483642 -2147483619 -2147483623 -2147483641 -2147483616 -2147483615 
		-2147483632 -2147483613 -2147483642;
	setAttr ".sma" 180;
	setAttr ".m2015" yes;
createNode polySplit -n "polySplit5";
	rename -uid "7F6E04DA-4214-1A7C-BCEC-B289A4D70842";
	setAttr -s 9 ".e[0:8]"  0.146244 0.85375601 0.85375601 0.146244 0.146244
		 0.146244 0.146244 0.146244 0.146244;
	setAttr -s 9 ".d[0:8]"  -2147483636 -2147483591 -2147483607 -2147483635 -2147483634 -2147483611 
		-2147483595 -2147483633 -2147483636;
	setAttr ".sma" 180;
	setAttr ".m2015" yes;
createNode polySplit -n "polySplit6";
	rename -uid "237E6267-4444-AB17-399D-D29F8566A830";
	setAttr -s 9 ".e[0:8]"  0.84480602 0.84480602 0.155194 0.155194 0.155194
		 0.155194 0.155194 0.155194 0.84480602;
	setAttr -s 9 ".d[0:8]"  -2147483607 -2147483591 -2147483588 -2147483581 -2147483582 -2147483583 
		-2147483584 -2147483585 -2147483607;
	setAttr ".sma" 180;
	setAttr ".m2015" yes;
createNode polySplit -n "polySplit7";
	rename -uid "6936FB77-4EF2-A792-57F9-8998C3E592DB";
	setAttr -s 9 ".e[0:8]"  0.82041401 0.82041401 0.17958599 0.17958599
		 0.17958599 0.17958599 0.17958599 0.17958599 0.82041401;
	setAttr -s 9 ".d[0:8]"  -2147483607 -2147483591 -2147483570 -2147483569 -2147483568 -2147483567 
		-2147483566 -2147483565 -2147483607;
	setAttr ".sma" 180;
	setAttr ".m2015" yes;
createNode polySplit -n "polySplit8";
	rename -uid "6B3984EA-4BA8-BDD3-1797-23A481ADCB8F";
	setAttr -s 9 ".e[0:8]"  0.754861 0.754861 0.245139 0.245139 0.245139
		 0.245139 0.245139 0.245139 0.754861;
	setAttr -s 9 ".d[0:8]"  -2147483607 -2147483591 -2147483554 -2147483553 -2147483552 -2147483551 
		-2147483550 -2147483549 -2147483607;
	setAttr ".sma" 180;
	setAttr ".m2015" yes;
createNode polySplit -n "polySplit9";
	rename -uid "698F1702-40A0-1864-6089-208AEEA61F23";
	setAttr -s 17 ".e[0:16]"  0.82853401 0.17146599 0.17146599 0.82853401
		 0.82853401 0.82853401 0.82853401 0.82853401 0.17146599 0.17146599 0.17146599 0.17146599
		 0.17146599 0.82853401 0.82853401 0.17146599 0.82853401;
	setAttr -s 17 ".d[0:16]"  -2147483642 -2147483603 -2147483574 -2147483561 -2147483545 -2147483529 
		-2147483623 -2147483641 -2147483600 -2147483599 -2147483531 -2147483547 -2147483563 -2147483580 -2147483632 -2147483597 -2147483642;
	setAttr ".sma" 180;
	setAttr ".m2015" yes;
createNode polySplit -n "polySplit10";
	rename -uid "9B597314-4D8B-CE57-B7A3-328466A91CCD";
	setAttr -s 17 ".e[0:16]"  0.82187802 0.178122 0.178122 0.82187802 0.82187802
		 0.82187802 0.82187802 0.82187802 0.178122 0.178122 0.178122 0.178122 0.178122 0.82187802
		 0.82187802 0.178122 0.82187802;
	setAttr -s 17 ".d[0:16]"  -2147483642 -2147483523 -2147483522 -2147483561 -2147483545 -2147483529 
		-2147483623 -2147483641 -2147483516 -2147483515 -2147483514 -2147483513 -2147483512 -2147483580 -2147483632 -2147483509 -2147483642;
	setAttr ".sma" 180;
	setAttr ".m2015" yes;
createNode polySplit -n "polySplit11";
	rename -uid "4F0B89EA-4991-F350-281A-B6BDEFD5F249";
	setAttr -s 17 ".e[0:16]"  0.74620402 0.25379601 0.25379601 0.74620402
		 0.74620402 0.74620402 0.74620402 0.74620402 0.25379601 0.25379601 0.25379601 0.25379601
		 0.25379601 0.74620402 0.74620402 0.25379601 0.74620402;
	setAttr -s 17 ".d[0:16]"  -2147483642 -2147483491 -2147483490 -2147483561 -2147483545 -2147483529 
		-2147483623 -2147483641 -2147483484 -2147483483 -2147483482 -2147483481 -2147483480 -2147483580 -2147483632 -2147483477 -2147483642;
	setAttr ".sma" 180;
	setAttr ".m2015" yes;
createNode polySplit -n "polySplit12";
	rename -uid "4257AC99-48C8-FDC1-0BFB-01AE497A3B58";
	setAttr -s 17 ".e[0:16]"  0.565961 0.434039 0.434039 0.565961 0.565961
		 0.565961 0.565961 0.565961 0.434039 0.434039 0.434039 0.434039 0.434039 0.565961
		 0.565961 0.434039 0.565961;
	setAttr -s 17 ".d[0:16]"  -2147483642 -2147483459 -2147483458 -2147483561 -2147483545 -2147483529 
		-2147483623 -2147483641 -2147483452 -2147483451 -2147483450 -2147483449 -2147483448 -2147483580 -2147483632 -2147483445 -2147483642;
	setAttr ".sma" 180;
	setAttr ".m2015" yes;
createNode polySplit -n "polySplit13";
	rename -uid "CA2411C2-4D02-3248-8EB5-EFBFDCF0E203";
	setAttr -s 17 ".e[0:16]"  0.47650999 0.52349001 0.52349001 0.47650999
		 0.47650999 0.47650999 0.47650999 0.47650999 0.52349001 0.52349001 0.52349001 0.52349001
		 0.52349001 0.47650999 0.47650999 0.52349001 0.47650999;
	setAttr -s 17 ".d[0:16]"  -2147483642 -2147483427 -2147483426 -2147483561 -2147483545 -2147483529 
		-2147483623 -2147483641 -2147483420 -2147483419 -2147483418 -2147483417 -2147483416 -2147483580 -2147483632 -2147483413 -2147483642;
	setAttr ".sma" 180;
	setAttr ".m2015" yes;
createNode polySplit -n "polySplit14";
	rename -uid "5BC91592-4101-766A-4A55-E58B918FB13B";
	setAttr -s 19 ".e[0:18]"  0.70400101 0.70400101 0.70400101 0.70400101
		 0.70400101 0.70400101 0.70400101 0.29599899 0.29599899 0.29599899 0.29599899 0.29599899
		 0.29599899 0.29599899 0.29599899 0.29599899 0.29599899 0.29599899 0.70400101;
	setAttr -s 19 ".d[0:18]"  -2147483607 -2147483591 -2147483499 -2147483467 -2147483435 -2147483403 
		-2147483371 -2147483538 -2147483537 -2147483375 -2147483407 -2147483439 -2147483471 -2147483503 -2147483536 -2147483535 -2147483534 -2147483533 
		-2147483607;
	setAttr ".sma" 180;
	setAttr ".m2015" yes;
createNode polySplit -n "polySplit15";
	rename -uid "F5D2D50B-4D6D-7890-7FC2-0D8E4C636900";
	setAttr -s 19 ".e[0:18]"  0.63321501 0.63321501 0.63321501 0.63321501
		 0.63321501 0.63321501 0.63321501 0.36678499 0.36678499 0.36678499 0.36678499 0.36678499
		 0.36678499 0.36678499 0.36678499 0.36678499 0.36678499 0.36678499 0.63321501;
	setAttr -s 19 ".d[0:18]"  -2147483607 -2147483591 -2147483499 -2147483467 -2147483435 -2147483403 
		-2147483371 -2147483357 -2147483356 -2147483355 -2147483354 -2147483353 -2147483352 -2147483351 -2147483350 -2147483349 -2147483348 -2147483347 
		-2147483607;
	setAttr ".sma" 180;
	setAttr ".m2015" yes;
createNode polySplit -n "polySplit16";
	rename -uid "25F4874C-4D7B-9F83-EF20-A6933ADAD62E";
	setAttr -s 19 ".e[0:18]"  0.49262601 0.49262601 0.49262601 0.49262601
		 0.49262601 0.49262601 0.49262601 0.50737399 0.50737399 0.50737399 0.50737399 0.50737399
		 0.50737399 0.50737399 0.50737399 0.50737399 0.50737399 0.50737399 0.49262601;
	setAttr -s 19 ".d[0:18]"  -2147483607 -2147483591 -2147483499 -2147483467 -2147483435 -2147483403 
		-2147483371 -2147483321 -2147483320 -2147483319 -2147483318 -2147483317 -2147483316 -2147483315 -2147483314 -2147483313 -2147483312 -2147483311 
		-2147483607;
	setAttr ".sma" 180;
	setAttr ".m2015" yes;
createNode polyExtrudeFace -n "polyExtrudeFace1";
	rename -uid "1F3A2741-48B6-15D9-0120-6F9FFC7CE487";
	setAttr ".ics" -type "componentList" 6 "f[15]" "f[35:36]" "f[42]" "f[50]" "f[58]" "f[63]";
	setAttr ".ix" -type "matrix" 2947.7880077922136 0 0 0 0 64.751470315297624 0 0 0 0 2709.2401659373472 0
		 0 -28.02794586952383 0 1;
	setAttr ".ws" yes;
	setAttr ".pvt" -type "float3" -3.1776927 0.043477893 -4.9879193 ;
	setAttr ".rs" 47135;
	setAttr ".c[0]"  0 1 1;
	setAttr ".cbn" -type "double3" -11.170249956255565 0.04347789288124982 -11.076213671691358 ;
	setAttr ".cbx" -type "double3" 4.8148647283759578 0.04347789288124982 1.1003753491908921 ;
createNode polyTweak -n "polyTweak1";
	rename -uid "583A45AC-4FCC-F496-CA7D-379410045219";
	setAttr ".uopa" yes;
	setAttr -s 10 ".tk";
	setAttr ".tk[17]" -type "float3" 0.0587098 0 0.10002476 ;
	setAttr ".tk[25]" -type "float3" 0.0362509 0 0 ;
	setAttr ".tk[37]" -type "float3" 0 0 0.042846229 ;
	setAttr ".tk[44]" -type "float3" -0.02368388 0 -0.065173119 ;
	setAttr ".tk[52]" -type "float3" 0 0 -0.069542378 ;
	setAttr ".tk[61]" -type "float3" 0 0 0.064267695 ;
	setAttr ".tk[65]" -type "float3" 0.030902125 0 0 ;
	setAttr ".tk[81]" -type "float3" 0.037555911 0 0 ;
	setAttr ".tk[159]" -type "float3" 0 0 0.1279292 ;
	setAttr ".tk[177]" -type "float3" 0 0 0.21037352 ;
createNode polyBevel3 -n "polyBevel1";
	rename -uid "088D3771-4E76-EBDF-EFAF-41B93CB93B0F";
	setAttr ".uopa" yes;
	setAttr ".ics" -type "componentList" 1 "e[419:420]";
	setAttr ".ix" -type "matrix" 2947.7880077922136 0 0 0 0 64.751470315297624 0 0 0 0 2709.2401659373472 0
		 0 -28.02794586952383 0 1;
	setAttr ".ws" yes;
	setAttr ".oaf" yes;
	setAttr ".at" 180;
	setAttr ".sn" yes;
	setAttr ".mv" yes;
	setAttr ".mvt" 0.0001;
	setAttr ".sa" 30;
createNode polyTweak -n "polyTweak2";
	rename -uid "D2A63E5A-4E7F-79F1-9CCC-A4B0C0020B5C";
	setAttr ".uopa" yes;
	setAttr -s 18 ".tk";
	setAttr ".tk[198]" -type "float3" 0 4.4264345 0 ;
	setAttr ".tk[199]" -type "float3" 0 4.4264345 0 ;
	setAttr ".tk[200]" -type "float3" 0 4.4264345 0 ;
	setAttr ".tk[201]" -type "float3" 0 4.4264345 0 ;
	setAttr ".tk[202]" -type "float3" 0 4.4264345 0 ;
	setAttr ".tk[203]" -type "float3" 0 4.4264345 0 ;
	setAttr ".tk[204]" -type "float3" 0 4.4264345 0 ;
	setAttr ".tk[205]" -type "float3" 0 4.4264345 0 ;
	setAttr ".tk[206]" -type "float3" 0 4.4264345 0 ;
	setAttr ".tk[207]" -type "float3" 0 4.4264345 0 ;
	setAttr ".tk[208]" -type "float3" 0 4.4264345 0 ;
	setAttr ".tk[209]" -type "float3" 0 4.4264345 0 ;
	setAttr ".tk[210]" -type "float3" 0 4.4264345 0 ;
	setAttr ".tk[211]" -type "float3" 0 4.4264345 0 ;
	setAttr ".tk[212]" -type "float3" 0 4.4264345 0 ;
	setAttr ".tk[213]" -type "float3" 0 4.4264345 0 ;
createNode polyBevel3 -n "polyBevel2";
	rename -uid "41E685FD-4249-B3D5-ECEC-8ABEAC65F419";
	setAttr ".uopa" yes;
	setAttr ".ics" -type "componentList" 1 "e[430:433]";
	setAttr ".ix" -type "matrix" 2947.7880077922136 0 0 0 0 64.751470315297624 0 0 0 0 2709.2401659373472 0
		 0 -28.02794586952383 0 1;
	setAttr ".ws" yes;
	setAttr ".oaf" yes;
	setAttr ".at" 180;
	setAttr ".sn" yes;
	setAttr ".mv" yes;
	setAttr ".mvt" 0.0001;
	setAttr ".sa" 30;
createNode polyBevel3 -n "polyBevel3";
	rename -uid "71E3078B-42D9-F02B-10B9-F7A304B690B0";
	setAttr ".uopa" yes;
	setAttr ".ics" -type "componentList" 2 "e[445]" "e[450]";
	setAttr ".ix" -type "matrix" 2947.7880077922136 0 0 0 0 64.751470315297624 0 0 0 0 2709.2401659373472 0
		 0 -28.02794586952383 0 1;
	setAttr ".ws" yes;
	setAttr ".oaf" yes;
	setAttr ".at" 180;
	setAttr ".sn" yes;
	setAttr ".mv" yes;
	setAttr ".mvt" 0.0001;
	setAttr ".sa" 30;
createNode polyTweak -n "polyTweak3";
	rename -uid "DB775155-4833-8EB9-4965-FBBE50DD04D1";
	setAttr ".uopa" yes;
	setAttr -s 7 ".tk";
	setAttr ".tk[215]" -type "float3" 0 0 -0.027641047 ;
	setAttr ".tk[218]" -type "float3" 0 0 -0.027641047 ;
	setAttr ".tk[231]" -type "float3" 0 0 -0.027641047 ;
	setAttr ".tk[232]" -type "float3" 0 0 -0.027641047 ;
createNode polyBevel3 -n "polyBevel4";
	rename -uid "A8A6835F-44D1-8623-7634-D1B0E5892DB7";
	setAttr ".uopa" yes;
	setAttr ".ics" -type "componentList" 1 "e[390]";
	setAttr ".ix" -type "matrix" 2947.7880077922136 0 0 0 0 64.751470315297624 0 0 0 0 2709.2401659373472 0
		 0 -28.02794586952383 0 1;
	setAttr ".ws" yes;
	setAttr ".oaf" yes;
	setAttr ".at" 180;
	setAttr ".sn" yes;
	setAttr ".mv" yes;
	setAttr ".mvt" 0.0001;
	setAttr ".sa" 30;
createNode polyBevel3 -n "polyBevel5";
	rename -uid "ADAB1401-4115-D2DE-C1DE-A98AB19EE2BA";
	setAttr ".uopa" yes;
	setAttr ".ics" -type "componentList" 1 "e[383]";
	setAttr ".ix" -type "matrix" 2947.7880077922136 0 0 0 0 64.751470315297624 0 0 0 0 2709.2401659373472 0
		 0 -28.02794586952383 0 1;
	setAttr ".ws" yes;
	setAttr ".oaf" yes;
	setAttr ".at" 180;
	setAttr ".sn" yes;
	setAttr ".mv" yes;
	setAttr ".mvt" 0.0001;
	setAttr ".sa" 30;
createNode polyBevel3 -n "polyBevel6";
	rename -uid "00A8066E-4B56-9A38-DDEB-C19EC49F9F82";
	setAttr ".uopa" yes;
	setAttr ".ics" -type "componentList" 2 "e[380]" "e[392]";
	setAttr ".ix" -type "matrix" 2947.7880077922136 0 0 0 0 64.751470315297624 0 0 0 0 2709.2401659373472 0
		 0 -28.02794586952383 0 1;
	setAttr ".ws" yes;
	setAttr ".oaf" yes;
	setAttr ".at" 180;
	setAttr ".sn" yes;
	setAttr ".mv" yes;
	setAttr ".mvt" 0.0001;
	setAttr ".sa" 30;
createNode polyBevel3 -n "polyBevel7";
	rename -uid "8E74E733-418B-6A3A-9055-94B0C4503423";
	setAttr ".uopa" yes;
	setAttr ".ics" -type "componentList" 3 "e[375]" "e[377]" "e[386]";
	setAttr ".ix" -type "matrix" 2947.7880077922136 0 0 0 0 64.751470315297624 0 0 0 0 2709.2401659373472 0
		 0 -28.02794586952383 0 1;
	setAttr ".ws" yes;
	setAttr ".oaf" yes;
	setAttr ".at" 180;
	setAttr ".sn" yes;
	setAttr ".mv" yes;
	setAttr ".mvt" 0.0001;
	setAttr ".sa" 30;
createNode polyTweak -n "polyTweak4";
	rename -uid "C2BBF8DF-4D66-305D-4FAF-ACAF9054FB97";
	setAttr ".uopa" yes;
	setAttr -s 44 ".tk";
	setAttr ".tk[24]" -type "float3" -0.0048649516 1.2773433 0.00016081419 ;
	setAttr ".tk[53]" -type "float3" 0.0049885246 1.2773433 0.00016081419 ;
	setAttr ".tk[54]" -type "float3" 0.0049885246 1.2773433 -0.0037665176 ;
	setAttr ".tk[58]" -type "float3" -0.0049885362 1.2773433 0.0028340097 ;
	setAttr ".tk[59]" -type "float3" -0.0028769954 1.2773433 0.0028340097 ;
	setAttr ".tk[149]" -type "float3" 0.05087873 2.3964467 0 ;
	setAttr ".tk[150]" -type "float3" 0.05087873 2.3964467 0 ;
	setAttr ".tk[168]" -type "float3" 0 0 -0.072273813 ;
	setAttr ".tk[200]" -type "float3" -0.0048831948 1.2773433 0.0037718993 ;
	setAttr ".tk[201]" -type "float3" -0.0049829222 1.2773433 0.0047356593 ;
	setAttr ".tk[203]" -type "float3" -0.0044756043 1.2773433 0.0050030081 ;
	setAttr ".tk[204]" -type "float3" -0.0044804616 1.2773433 0.0052389209 ;
	setAttr ".tk[205]" -type "float3" -0.0041675116 1.2773433 0.0051347902 ;
	setAttr ".tk[208]" -type "float3" -0.0032571196 1.2773433 0.0049969377 ;
	setAttr ".tk[209]" -type "float3" -0.0035629971 1.2773433 0.0051347902 ;
	setAttr ".tk[210]" -type "float3" -0.0032579121 1.2773433 0.0052517108 ;
	setAttr ".tk[213]" -type "float3" -0.0027695175 1.2773433 0.0047203107 ;
	setAttr ".tk[214]" -type "float3" -0.0028769954 1.2773433 0.0037496125 ;
	setAttr ".tk[216]" -type "float3" -0.0047597829 1.2773433 0.0046025468 ;
	setAttr ".tk[217]" -type "float3" -0.0048570838 1.2773433 0.0047355974 ;
	setAttr ".tk[218]" -type "float3" -0.0046493621 1.2773433 0.0048271935 ;
	setAttr ".tk[221]" -type "float3" -0.0029863592 1.2773433 0.0045882049 ;
	setAttr ".tk[222]" -type "float3" -0.0030909455 1.2773433 0.004816154 ;
	setAttr ".tk[223]" -type "float3" -0.0028866138 1.2773433 0.00472074 ;
	setAttr ".tk[226]" -type "float3" -0.0036115232 1.2773433 -0.0036007995 ;
	setAttr ".tk[229]" -type "float3" -0.0045166421 1.2773433 -0.0019201858 ;
	setAttr ".tk[232]" -type "float3" -0.0032442249 1.2773433 -0.0039312085 ;
	setAttr ".tk[233]" -type "float3" -0.0024280262 1.2773433 -0.00443521 ;
	setAttr ".tk[238]" -type "float3" -0.00090637885 1.2773433 -0.0050237197 ;
	setAttr ".tk[239]" -type "float3" 0.00030871489 1.2773433 -0.0052517145 ;
	setAttr ".tk[244]" -type "float3" 0.0027546152 1.2773433 -0.0049503134 ;
	setAttr ".tk[246]" -type "float3" 0.0015531116 1.2773433 -0.0052517145 ;
	setAttr ".tk[250]" -type "float3" -0.0013283835 1.2773433 -0.00099797884 ;
	setAttr ".tk[251]" -type "float3" -0.00078798365 1.2773433 -0.00076314399 ;
	setAttr ".tk[252]" -type "float3" -0.00030114449 1.2773433 -0.0013639408 ;
	setAttr ".tk[256]" -type "float3" -0.0028769954 1.2773433 0.00082522776 ;
	setAttr ".tk[257]" -type "float3" -0.0023738581 1.2773433 -0.00021567788 ;
	setAttr ".tk[262]" -type "float3" 0.0016271605 1.2773433 -0.0014277892 ;
	setAttr ".tk[263]" -type "float3" 0.0021858031 1.2773433 -0.00085823168 ;
	setAttr ".tk[264]" -type "float3" 0.0026802504 1.2773433 -0.0011627568 ;
	setAttr ".tk[268]" -type "float3" 3.7252903e-09 2.3841858e-07 0 ;
	setAttr ".tk[269]" -type "float3" 3.7252903e-09 2.3841858e-07 0 ;
createNode polySplit -n "polySplit17";
	rename -uid "97DA70D5-4E4A-013B-FAB8-0EB4CCF5ABDA";
	setAttr -s 32 ".e[0:31]"  0.82459801 0.82459801 0.82459801 0.82459801
		 0.175402 0.82459801 0.175402 0.82459801 0.175402 0.82459801 0.175402 0.175402 0.82459801
		 0.82459801 0.175402 0.82459801 0.175402 0.82459801 0.175402 0.82459801 0.82459801
		 0.82459801 0.82459801 0.82459801 0.175402 0.82459801 0.175402 0.82459801 0.175402
		 0.82459801 0.175402 0.82459801;
	setAttr -s 32 ".d[0:31]"  -2147483277 -2147483275 -2147483237 -2147483218 -2147483217 -2147483236 
		-2147483235 -2147483234 -2147483233 -2147483216 -2147483215 -2147483232 -2147483274 -2147483144 -2147483143 -2147483146 -2147483145 -2147483142 
		-2147483141 -2147483271 -2147483268 -2147483267 -2147483270 -2147483174 -2147483173 -2147483176 -2147483175 -2147483194 -2147483193 -2147483204 
		-2147483203 -2147483277;
	setAttr ".sma" 180;
	setAttr ".m2015" yes;
createNode polySplit -n "polySplit18";
	rename -uid "AC1EAA60-44AE-A728-56CB-CB80B3D6D9B9";
	setAttr -s 32 ".e[0:31]"  0.737405 0.737405 0.737405 0.737405 0.262595
		 0.737405 0.262595 0.737405 0.262595 0.737405 0.262595 0.262595 0.737405 0.737405
		 0.262595 0.737405 0.262595 0.737405 0.262595 0.737405 0.737405 0.737405 0.737405
		 0.737405 0.262595 0.737405 0.262595 0.737405 0.262595 0.737405 0.262595 0.737405;
	setAttr -s 32 ".d[0:31]"  -2147483277 -2147483275 -2147483237 -2147483218 -2147483131 -2147483236 
		-2147483129 -2147483234 -2147483127 -2147483216 -2147483125 -2147483124 -2147483274 -2147483144 -2147483121 -2147483146 -2147483119 -2147483142 
		-2147483117 -2147483271 -2147483268 -2147483267 -2147483270 -2147483174 -2147483111 -2147483176 -2147483109 -2147483194 -2147483107 -2147483204 
		-2147483105 -2147483277;
	setAttr ".sma" 180;
	setAttr ".m2015" yes;
createNode polySplit -n "polySplit19";
	rename -uid "76CD1287-40CD-449D-E217-4BB6FC9FBC0D";
	setAttr -s 32 ".e[0:31]"  0.65243 0.65243 0.65243 0.65243 0.34757 0.65243
		 0.34757 0.65243 0.34757 0.65243 0.34757 0.34757 0.65243 0.65243 0.34757 0.65243 0.34757
		 0.65243 0.34757 0.65243 0.65243 0.65243 0.65243 0.65243 0.34757 0.65243 0.34757 0.65243
		 0.34757 0.65243 0.34757 0.65243;
	setAttr -s 32 ".d[0:31]"  -2147483277 -2147483275 -2147483237 -2147483218 -2147483069 -2147483236 
		-2147483067 -2147483234 -2147483065 -2147483216 -2147483063 -2147483062 -2147483274 -2147483144 -2147483059 -2147483146 -2147483057 -2147483142 
		-2147483055 -2147483271 -2147483268 -2147483267 -2147483270 -2147483174 -2147483049 -2147483176 -2147483047 -2147483194 -2147483045 -2147483204 
		-2147483043 -2147483277;
	setAttr ".sma" 180;
	setAttr ".m2015" yes;
createNode polySplit -n "polySplit20";
	rename -uid "8B9CB0C2-44B1-E4C2-F1C7-61A01ADDE20F";
	setAttr -s 32 ".e[0:31]"  0.35164601 0.35164601 0.35164601 0.35164601
		 0.64835399 0.35164601 0.64835399 0.35164601 0.64835399 0.35164601 0.64835399 0.64835399
		 0.35164601 0.35164601 0.64835399 0.35164601 0.64835399 0.35164601 0.64835399 0.35164601
		 0.35164601 0.35164601 0.35164601 0.35164601 0.64835399 0.35164601 0.64835399 0.35164601
		 0.64835399 0.35164601 0.64835399 0.35164601;
	setAttr -s 32 ".d[0:31]"  -2147483277 -2147483275 -2147483237 -2147483218 -2147483007 -2147483236 
		-2147483005 -2147483234 -2147483003 -2147483216 -2147483001 -2147483000 -2147483274 -2147483144 -2147482997 -2147483146 -2147482995 -2147483142 
		-2147482993 -2147483271 -2147483268 -2147483267 -2147483270 -2147483174 -2147482987 -2147483176 -2147482985 -2147483194 -2147482983 -2147483204 
		-2147482981 -2147483277;
	setAttr ".sma" 180;
	setAttr ".m2015" yes;
createNode polySplit -n "polySplit21";
	rename -uid "4E7A9762-4377-A85D-1B22-789EF3A6DDB8";
	setAttr -s 5 ".e[0:4]"  1 0.62826002 0.73415399 0.63520002 0;
	setAttr -s 5 ".d[0:4]"  -2147483334 -2147483316 -2147483352 -2147483543 -2147483182;
	setAttr ".sma" 180;
	setAttr ".m2015" yes;
createNode polySplit -n "polySplit22";
	rename -uid "5AB74632-43C2-669A-9E0C-A3A0D3CC6434";
	setAttr -s 2 ".e[0:1]"  1 0;
	setAttr -s 2 ".d[0:1]"  -2147483180 -2147483189;
	setAttr ".sma" 180;
	setAttr ".m2015" yes;
createNode polySplit -n "polySplit23";
	rename -uid "93DB0128-42E8-C3DB-2122-01901FEE81AD";
	setAttr -s 2 ".e[0:1]"  1 1;
	setAttr -s 2 ".d[0:1]"  -2147483188 -2147483581;
	setAttr ".sma" 180;
	setAttr ".m2015" yes;
createNode polySplit -n "polySplit24";
	rename -uid "21E87190-47BA-5A3A-9C24-4E94273A9F86";
	setAttr -s 2 ".e[0:1]"  1 1;
	setAttr -s 2 ".d[0:1]"  -2147483200 -2147483630;
	setAttr ".sma" 180;
	setAttr ".m2015" yes;
createNode polySplit -n "polySplit25";
	rename -uid "9CFCE781-4C47-C26B-B990-C89A90CB8868";
	setAttr -s 4 ".e[0:3]"  1 0.60975599 0.67736697 1;
	setAttr -s 4 ".d[0:3]"  -2147483613 -2147483598 -2147483524 -2147483495;
	setAttr ".sma" 180;
	setAttr ".m2015" yes;
createNode polySplit -n "polySplit26";
	rename -uid "182B54CF-4A9E-6784-43E8-AFA1CFF70D21";
	setAttr -s 2 ".e[0:1]"  0 1;
	setAttr -s 2 ".d[0:1]"  -2147483257 -2147483523;
	setAttr ".sma" 180;
	setAttr ".m2015" yes;
createNode polySplit -n "polySplit27";
	rename -uid "26FE08D6-4670-BE9E-D6B1-10AE20DF96BE";
	setAttr -s 2 ".e[0:1]"  1 1;
	setAttr -s 2 ".d[0:1]"  -2147483159 -2147483523;
	setAttr ".sma" 180;
	setAttr ".m2015" yes;
createNode polySplit -n "polySplit28";
	rename -uid "3C899A31-47F1-097E-5EC9-D293DC294DC8";
	setAttr -s 2 ".e[0:1]"  0 0;
	setAttr -s 2 ".d[0:1]"  -2147483160 -2147483537;
	setAttr ".sma" 180;
	setAttr ".m2015" yes;
createNode polySplit -n "polySplit29";
	rename -uid "6D591246-4819-6424-C58C-BB8EC3E02937";
	setAttr -s 2 ".e[0:1]"  1 1;
	setAttr -s 2 ".d[0:1]"  -2147483152 -2147483522;
	setAttr ".sma" 180;
	setAttr ".m2015" yes;
createNode polySplit -n "polySplit30";
	rename -uid "983DBB74-492A-2FA5-8B33-FE9F1219AFDD";
	setAttr -s 2 ".e[0:1]"  0 0;
	setAttr -s 2 ".d[0:1]"  -2147483168 -2147483537;
	setAttr ".sma" 180;
	setAttr ".m2015" yes;
createNode polySplit -n "polySplit31";
	rename -uid "E1CC49C7-4671-02C4-8719-0BACA3EF54CE";
	setAttr -s 2 ".e[0:1]"  0 0;
	setAttr -s 2 ".d[0:1]"  -2147483153 -2147483536;
	setAttr ".sma" 180;
	setAttr ".m2015" yes;
createNode polySplit -n "polySplit32";
	rename -uid "F65BD6C8-4C3A-4A6B-19EA-DFB253FD0995";
	setAttr -s 2 ".e[0:1]"  0 1;
	setAttr -s 2 ".d[0:1]"  -2147483543 -2147483352;
	setAttr ".sma" 180;
	setAttr ".m2015" yes;
createNode polySplit -n "polySplit33";
	rename -uid "928C8F30-43BB-08DA-D536-E7BF15E6C192";
	setAttr -s 2 ".e[0:1]"  1 1;
	setAttr -s 2 ".d[0:1]"  -2147483181 -2147483543;
	setAttr ".sma" 180;
	setAttr ".m2015" yes;
createNode polySplit -n "polySplit34";
	rename -uid "D25DE5CC-45E3-510B-5C36-F4A59EBAEB92";
	setAttr -s 2 ".e[0:1]"  0 1;
	setAttr -s 2 ".d[0:1]"  -2147483551 -2147483520;
	setAttr ".sma" 180;
	setAttr ".m2015" yes;
createNode polySplit -n "polySplit35";
	rename -uid "CE4C8699-4813-199D-3AF6-C6A306E9EC89";
	setAttr -s 2 ".e[0:1]"  0 1;
	setAttr -s 2 ".d[0:1]"  -2147483354 -2147483318;
	setAttr ".sma" 180;
	setAttr ".m2015" yes;
createNode polyTweak -n "polyTweak5";
	rename -uid "78DB5D82-44E9-BAF9-829A-3297900C3E2A";
	setAttr ".uopa" yes;
	setAttr -s 13 ".tk";
	setAttr ".tk[149]" -type "float3" 0.012674759 -0.92734468 -0.0049570464 ;
	setAttr ".tk[150]" -type "float3" 0.012674759 -0.92734468 -0.0049570464 ;
	setAttr ".tk[194]" -type "float3" -0.090976261 -0.073201671 0.011661857 ;
	setAttr ".tk[195]" -type "float3" -0.059797253 -0.073201671 -0.0194325 ;
	setAttr ".tk[288]" -type "float3" -0.085958429 3.375078e-14 0.02000715 ;
	setAttr ".tk[289]" -type "float3" -0.03066979 3.375078e-14 -0.0017902157 ;
	setAttr ".tk[319]" -type "float3" -0.095117271 0.15254951 0.042987067 ;
	setAttr ".tk[320]" -type "float3" -0.007611271 0.15254951 0.044588219 ;
	setAttr ".tk[350]" -type "float3" -0.089263961 3.1086245e-14 0.055233549 ;
	setAttr ".tk[351]" -type "float3" 0.0011971138 3.1086245e-14 0.12141232 ;
	setAttr ".tk[381]" -type "float3" -0.0016221891 -0.20766163 -0.0054340153 ;
	setAttr ".tk[382]" -type "float3" -0.0016221891 -0.20766163 -0.0054340153 ;
createNode deleteComponent -n "deleteComponent1";
	rename -uid "C011DF25-4B7A-2E2C-726B-DC9072C569DE";
	setAttr ".dc" -type "componentList" 1 "e[784]";
createNode deleteComponent -n "deleteComponent2";
	rename -uid "261814E0-47E5-6DC9-B60B-E2B740676D42";
	setAttr ".dc" -type "componentList" 1 "e[294]";
createNode polyMergeVert -n "polyMergeVert1";
	rename -uid "BA7AC2DE-4C2B-CDB1-EC74-53BDCA0BE956";
	setAttr ".ics" -type "componentList" 2 "vtx[148]" "vtx[167]";
	setAttr ".ix" -type "matrix" 2947.7880077922136 0 0 0 0 64.751470315297624 0 0 0 0 2709.2401659373472 0
		 0 -28.02794586952383 0 1;
	setAttr ".d" 1e-06;
createNode polyTweak -n "polyTweak6";
	rename -uid "E08513D4-4D02-5DD3-62B8-668AAD42BC02";
	setAttr ".uopa" yes;
	setAttr -s 14 ".tk";
	setAttr ".tk[54]" -type "float3" 0.10176255 0 0 ;
	setAttr ".tk[148]" -type "float3" 0.048217073 0 -0.057837106 ;
	setAttr ".tk[149]" -type "float3" -0.12755144 1.2212453e-14 0.10904394 ;
	setAttr ".tk[150]" -type "float3" -0.029965669 1.2212453e-14 0.22004199 ;
	setAttr ".tk[167]" -type "float3" -0.048217088 0 0.057837106 ;
	setAttr ".tk[290]" -type "float3" 0.038978003 0 0 ;
	setAttr ".tk[319]" -type "float3" 0.0093748504 0.12490431 -0.0005622466 ;
	setAttr ".tk[320]" -type "float3" -0.0036914567 -0.14039955 0.0029734508 ;
	setAttr ".tk[321]" -type "float3" 0.052911296 0 0 ;
	setAttr ".tk[350]" -type "float3" 0.014644394 0 -0.00072355138 ;
	setAttr ".tk[352]" -type "float3" 0.073518828 0 0 ;
	setAttr ".tk[381]" -type "float3" -0.078620039 0.036560852 0.10440937 ;
	setAttr ".tk[382]" -type "float3" 0.0023100504 1.7319479e-14 0.1642881 ;
	setAttr ".tk[383]" -type "float3" 0.074559465 0 0 ;
createNode polyMergeVert -n "polyMergeVert2";
	rename -uid "010FDE6F-424C-68BF-BDBD-6BBF58B4E737";
	setAttr ".ics" -type "componentList" 2 "vtx[148]" "vtx[167]";
	setAttr ".ix" -type "matrix" 2947.7880077922136 0 0 0 0 64.751470315297624 0 0 0 0 2709.2401659373472 0
		 0 -28.02794586952383 0 1;
	setAttr ".d" 1e-06;
createNode polyTweak -n "polyTweak7";
	rename -uid "991E85BB-4EE3-79CD-D90B-BB9D92BA42C5";
	setAttr ".uopa" yes;
	setAttr -s 2 ".tk";
	setAttr ".tk[148]" -type "float3" 0.010686226 0 -0.044923268 ;
	setAttr ".tk[167]" -type "float3" -0.037530854 0 0.10902622 ;
createNode polyTweak -n "polyTweak8";
	rename -uid "51F12861-42CA-8E16-69F4-CF973FCF142C";
	setAttr ".uopa" yes;
	setAttr ".tk[148]" -type "float3"  0 0 0.13486652;
createNode polySplit -n "polySplit36";
	rename -uid "1E3D19A2-45A7-8948-5F49-4D9D155F1E99";
	setAttr -s 2 ".e[0:1]"  0 0;
	setAttr -s 2 ".d[0:1]"  -2147483371 -2147483535;
	setAttr ".sma" 180;
	setAttr ".m2015" yes;
createNode polySplit -n "polySplit37";
	rename -uid "5B3805D3-4D65-42C5-12EB-6087D89998B9";
	setAttr -s 4 ".e[0:3]"  0 0.77420801 0.917925 1;
	setAttr -s 4 ".d[0:3]"  -2147483550 -2147483353 -2147483319 -2147483335;
	setAttr ".sma" 180;
	setAttr ".m2015" yes;
createNode script -n "uiConfigurationScriptNode";
	rename -uid "B892E938-46D1-AA8E-D2CB-DBBA4A94D059";
	setAttr ".b" -type "string" (
		"// Maya Mel UI Configuration File.\n//\n//  This script is machine generated.  Edit at your own risk.\n//\n//\n\nglobal string $gMainPane;\nif (`paneLayout -exists $gMainPane`) {\n\n\tglobal int $gUseScenePanelConfig;\n\tint    $useSceneConfig = $gUseScenePanelConfig;\n\tint    $menusOkayInPanels = `optionVar -q allowMenusInPanels`;\tint    $nVisPanes = `paneLayout -q -nvp $gMainPane`;\n\tint    $nPanes = 0;\n\tstring $editorName;\n\tstring $panelName;\n\tstring $itemFilterName;\n\tstring $panelConfig;\n\n\t//\n\t//  get current state of the UI\n\t//\n\tsceneUIReplacement -update $gMainPane;\n\n\t$panelName = `sceneUIReplacement -getNextPanel \"modelPanel\" (localizedPanelLabel(\"Top View\")) `;\n\tif (\"\" != $panelName) {\n\t\t$label = `panel -q -label $panelName`;\n\t\tmodelPanel -edit -l (localizedPanelLabel(\"Top View\")) -mbv $menusOkayInPanels  $panelName;\n\t\t$editorName = $panelName;\n        modelEditor -e \n            -camera \"top\" \n            -useInteractiveMode 0\n            -displayLights \"default\" \n            -displayAppearance \"smoothShaded\" \n            -activeOnly 0\n"
		+ "            -ignorePanZoom 0\n            -wireframeOnShaded 0\n            -headsUpDisplay 1\n            -holdOuts 1\n            -selectionHiliteDisplay 1\n            -useDefaultMaterial 0\n            -bufferMode \"double\" \n            -twoSidedLighting 0\n            -backfaceCulling 0\n            -xray 0\n            -jointXray 0\n            -activeComponentsXray 0\n            -displayTextures 0\n            -smoothWireframe 0\n            -lineWidth 1\n            -textureAnisotropic 0\n            -textureHilight 1\n            -textureSampling 2\n            -textureDisplay \"modulate\" \n            -textureMaxSize 16384\n            -fogging 0\n            -fogSource \"fragment\" \n            -fogMode \"linear\" \n            -fogStart 0\n            -fogEnd 100\n            -fogDensity 0.1\n            -fogColor 0.5 0.5 0.5 1 \n            -depthOfFieldPreview 1\n            -maxConstantTransparency 1\n            -rendererName \"vp2Renderer\" \n            -objectFilterShowInHUD 1\n            -isFiltered 0\n            -colorResolution 256 256 \n"
		+ "            -bumpResolution 512 512 \n            -textureCompression 0\n            -transparencyAlgorithm \"frontAndBackCull\" \n            -transpInShadows 0\n            -cullingOverride \"none\" \n            -lowQualityLighting 0\n            -maximumNumHardwareLights 1\n            -occlusionCulling 0\n            -shadingModel 0\n            -useBaseRenderer 0\n            -useReducedRenderer 0\n            -smallObjectCulling 0\n            -smallObjectThreshold -1 \n            -interactiveDisableShadows 0\n            -interactiveBackFaceCull 0\n            -sortTransparent 1\n            -controllers 1\n            -nurbsCurves 1\n            -nurbsSurfaces 1\n            -polymeshes 1\n            -subdivSurfaces 1\n            -planes 1\n            -lights 1\n            -cameras 1\n            -controlVertices 1\n            -hulls 1\n            -grid 1\n            -imagePlane 1\n            -joints 1\n            -ikHandles 1\n            -deformers 1\n            -dynamics 1\n            -particleInstancers 1\n            -fluids 1\n"
		+ "            -hairSystems 1\n            -follicles 1\n            -nCloths 1\n            -nParticles 1\n            -nRigids 1\n            -dynamicConstraints 1\n            -locators 1\n            -manipulators 1\n            -pluginShapes 1\n            -dimensions 1\n            -handles 1\n            -pivots 1\n            -textures 1\n            -strokes 1\n            -motionTrails 1\n            -clipGhosts 1\n            -greasePencils 1\n            -shadows 0\n            -captureSequenceNumber -1\n            -width 1\n            -height 1\n            -sceneRenderFilter 0\n            $editorName;\n        modelEditor -e -viewSelected 0 $editorName;\n        modelEditor -e \n            -pluginObjects \"gpuCacheDisplayFilter\" 1 \n            $editorName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextPanel \"modelPanel\" (localizedPanelLabel(\"Side View\")) `;\n\tif (\"\" != $panelName) {\n\t\t$label = `panel -q -label $panelName`;\n\t\tmodelPanel -edit -l (localizedPanelLabel(\"Side View\")) -mbv $menusOkayInPanels  $panelName;\n"
		+ "\t\t$editorName = $panelName;\n        modelEditor -e \n            -camera \"side\" \n            -useInteractiveMode 0\n            -displayLights \"default\" \n            -displayAppearance \"smoothShaded\" \n            -activeOnly 0\n            -ignorePanZoom 0\n            -wireframeOnShaded 0\n            -headsUpDisplay 1\n            -holdOuts 1\n            -selectionHiliteDisplay 1\n            -useDefaultMaterial 0\n            -bufferMode \"double\" \n            -twoSidedLighting 0\n            -backfaceCulling 0\n            -xray 0\n            -jointXray 0\n            -activeComponentsXray 0\n            -displayTextures 0\n            -smoothWireframe 0\n            -lineWidth 1\n            -textureAnisotropic 0\n            -textureHilight 1\n            -textureSampling 2\n            -textureDisplay \"modulate\" \n            -textureMaxSize 16384\n            -fogging 0\n            -fogSource \"fragment\" \n            -fogMode \"linear\" \n            -fogStart 0\n            -fogEnd 100\n            -fogDensity 0.1\n            -fogColor 0.5 0.5 0.5 1 \n"
		+ "            -depthOfFieldPreview 1\n            -maxConstantTransparency 1\n            -rendererName \"vp2Renderer\" \n            -objectFilterShowInHUD 1\n            -isFiltered 0\n            -colorResolution 256 256 \n            -bumpResolution 512 512 \n            -textureCompression 0\n            -transparencyAlgorithm \"frontAndBackCull\" \n            -transpInShadows 0\n            -cullingOverride \"none\" \n            -lowQualityLighting 0\n            -maximumNumHardwareLights 1\n            -occlusionCulling 0\n            -shadingModel 0\n            -useBaseRenderer 0\n            -useReducedRenderer 0\n            -smallObjectCulling 0\n            -smallObjectThreshold -1 \n            -interactiveDisableShadows 0\n            -interactiveBackFaceCull 0\n            -sortTransparent 1\n            -controllers 1\n            -nurbsCurves 1\n            -nurbsSurfaces 1\n            -polymeshes 1\n            -subdivSurfaces 1\n            -planes 1\n            -lights 1\n            -cameras 1\n            -controlVertices 1\n"
		+ "            -hulls 1\n            -grid 1\n            -imagePlane 1\n            -joints 1\n            -ikHandles 1\n            -deformers 1\n            -dynamics 1\n            -particleInstancers 1\n            -fluids 1\n            -hairSystems 1\n            -follicles 1\n            -nCloths 1\n            -nParticles 1\n            -nRigids 1\n            -dynamicConstraints 1\n            -locators 1\n            -manipulators 1\n            -pluginShapes 1\n            -dimensions 1\n            -handles 1\n            -pivots 1\n            -textures 1\n            -strokes 1\n            -motionTrails 1\n            -clipGhosts 1\n            -greasePencils 1\n            -shadows 0\n            -captureSequenceNumber -1\n            -width 1\n            -height 1\n            -sceneRenderFilter 0\n            $editorName;\n        modelEditor -e -viewSelected 0 $editorName;\n        modelEditor -e \n            -pluginObjects \"gpuCacheDisplayFilter\" 1 \n            $editorName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n"
		+ "\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextPanel \"modelPanel\" (localizedPanelLabel(\"Front View\")) `;\n\tif (\"\" != $panelName) {\n\t\t$label = `panel -q -label $panelName`;\n\t\tmodelPanel -edit -l (localizedPanelLabel(\"Front View\")) -mbv $menusOkayInPanels  $panelName;\n\t\t$editorName = $panelName;\n        modelEditor -e \n            -camera \"front\" \n            -useInteractiveMode 0\n            -displayLights \"default\" \n            -displayAppearance \"smoothShaded\" \n            -activeOnly 0\n            -ignorePanZoom 0\n            -wireframeOnShaded 0\n            -headsUpDisplay 1\n            -holdOuts 1\n            -selectionHiliteDisplay 1\n            -useDefaultMaterial 0\n            -bufferMode \"double\" \n            -twoSidedLighting 0\n            -backfaceCulling 0\n            -xray 0\n            -jointXray 0\n            -activeComponentsXray 0\n            -displayTextures 0\n            -smoothWireframe 0\n            -lineWidth 1\n            -textureAnisotropic 0\n            -textureHilight 1\n            -textureSampling 2\n"
		+ "            -textureDisplay \"modulate\" \n            -textureMaxSize 16384\n            -fogging 0\n            -fogSource \"fragment\" \n            -fogMode \"linear\" \n            -fogStart 0\n            -fogEnd 100\n            -fogDensity 0.1\n            -fogColor 0.5 0.5 0.5 1 \n            -depthOfFieldPreview 1\n            -maxConstantTransparency 1\n            -rendererName \"vp2Renderer\" \n            -objectFilterShowInHUD 1\n            -isFiltered 0\n            -colorResolution 256 256 \n            -bumpResolution 512 512 \n            -textureCompression 0\n            -transparencyAlgorithm \"frontAndBackCull\" \n            -transpInShadows 0\n            -cullingOverride \"none\" \n            -lowQualityLighting 0\n            -maximumNumHardwareLights 1\n            -occlusionCulling 0\n            -shadingModel 0\n            -useBaseRenderer 0\n            -useReducedRenderer 0\n            -smallObjectCulling 0\n            -smallObjectThreshold -1 \n            -interactiveDisableShadows 0\n            -interactiveBackFaceCull 0\n"
		+ "            -sortTransparent 1\n            -controllers 1\n            -nurbsCurves 1\n            -nurbsSurfaces 1\n            -polymeshes 1\n            -subdivSurfaces 1\n            -planes 1\n            -lights 1\n            -cameras 1\n            -controlVertices 1\n            -hulls 1\n            -grid 1\n            -imagePlane 1\n            -joints 1\n            -ikHandles 1\n            -deformers 1\n            -dynamics 1\n            -particleInstancers 1\n            -fluids 1\n            -hairSystems 1\n            -follicles 1\n            -nCloths 1\n            -nParticles 1\n            -nRigids 1\n            -dynamicConstraints 1\n            -locators 1\n            -manipulators 1\n            -pluginShapes 1\n            -dimensions 1\n            -handles 1\n            -pivots 1\n            -textures 1\n            -strokes 1\n            -motionTrails 1\n            -clipGhosts 1\n            -greasePencils 1\n            -shadows 0\n            -captureSequenceNumber -1\n            -width 1\n            -height 1\n"
		+ "            -sceneRenderFilter 0\n            $editorName;\n        modelEditor -e -viewSelected 0 $editorName;\n        modelEditor -e \n            -pluginObjects \"gpuCacheDisplayFilter\" 1 \n            $editorName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextPanel \"modelPanel\" (localizedPanelLabel(\"Persp View\")) `;\n\tif (\"\" != $panelName) {\n\t\t$label = `panel -q -label $panelName`;\n\t\tmodelPanel -edit -l (localizedPanelLabel(\"Persp View\")) -mbv $menusOkayInPanels  $panelName;\n\t\t$editorName = $panelName;\n        modelEditor -e \n            -camera \"persp\" \n            -useInteractiveMode 0\n            -displayLights \"default\" \n            -displayAppearance \"smoothShaded\" \n            -activeOnly 0\n            -ignorePanZoom 0\n            -wireframeOnShaded 0\n            -headsUpDisplay 1\n            -holdOuts 1\n            -selectionHiliteDisplay 1\n            -useDefaultMaterial 0\n            -bufferMode \"double\" \n            -twoSidedLighting 0\n            -backfaceCulling 0\n"
		+ "            -xray 0\n            -jointXray 0\n            -activeComponentsXray 0\n            -displayTextures 0\n            -smoothWireframe 0\n            -lineWidth 1\n            -textureAnisotropic 0\n            -textureHilight 1\n            -textureSampling 2\n            -textureDisplay \"modulate\" \n            -textureMaxSize 16384\n            -fogging 0\n            -fogSource \"fragment\" \n            -fogMode \"linear\" \n            -fogStart 0\n            -fogEnd 100\n            -fogDensity 0.1\n            -fogColor 0.5 0.5 0.5 1 \n            -depthOfFieldPreview 1\n            -maxConstantTransparency 1\n            -rendererName \"vp2Renderer\" \n            -objectFilterShowInHUD 1\n            -isFiltered 0\n            -colorResolution 256 256 \n            -bumpResolution 512 512 \n            -textureCompression 0\n            -transparencyAlgorithm \"frontAndBackCull\" \n            -transpInShadows 0\n            -cullingOverride \"none\" \n            -lowQualityLighting 0\n            -maximumNumHardwareLights 1\n            -occlusionCulling 0\n"
		+ "            -shadingModel 0\n            -useBaseRenderer 0\n            -useReducedRenderer 0\n            -smallObjectCulling 0\n            -smallObjectThreshold -1 \n            -interactiveDisableShadows 0\n            -interactiveBackFaceCull 0\n            -sortTransparent 1\n            -controllers 1\n            -nurbsCurves 1\n            -nurbsSurfaces 1\n            -polymeshes 1\n            -subdivSurfaces 1\n            -planes 1\n            -lights 1\n            -cameras 1\n            -controlVertices 1\n            -hulls 1\n            -grid 1\n            -imagePlane 1\n            -joints 1\n            -ikHandles 1\n            -deformers 1\n            -dynamics 1\n            -particleInstancers 1\n            -fluids 1\n            -hairSystems 1\n            -follicles 1\n            -nCloths 1\n            -nParticles 1\n            -nRigids 1\n            -dynamicConstraints 1\n            -locators 1\n            -manipulators 1\n            -pluginShapes 1\n            -dimensions 1\n            -handles 1\n            -pivots 1\n"
		+ "            -textures 1\n            -strokes 1\n            -motionTrails 1\n            -clipGhosts 1\n            -greasePencils 1\n            -shadows 0\n            -captureSequenceNumber -1\n            -width 1585\n            -height 716\n            -sceneRenderFilter 0\n            $editorName;\n        modelEditor -e -viewSelected 0 $editorName;\n        modelEditor -e \n            -pluginObjects \"gpuCacheDisplayFilter\" 1 \n            $editorName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextPanel \"outlinerPanel\" (localizedPanelLabel(\"ToggledOutliner\")) `;\n\tif (\"\" != $panelName) {\n\t\t$label = `panel -q -label $panelName`;\n\t\toutlinerPanel -edit -l (localizedPanelLabel(\"ToggledOutliner\")) -mbv $menusOkayInPanels  $panelName;\n\t\t$editorName = $panelName;\n        outlinerEditor -e \n            -showShapes 0\n            -showAssignedMaterials 0\n            -showTimeEditor 1\n            -showReferenceNodes 1\n            -showReferenceMembers 1\n            -showAttributes 0\n"
		+ "            -showConnected 0\n            -showAnimCurvesOnly 0\n            -showMuteInfo 0\n            -organizeByLayer 1\n            -organizeByClip 1\n            -showAnimLayerWeight 1\n            -autoExpandLayers 1\n            -autoExpand 0\n            -showDagOnly 1\n            -showAssets 1\n            -showContainedOnly 1\n            -showPublishedAsConnected 0\n            -showParentContainers 0\n            -showContainerContents 1\n            -ignoreDagHierarchy 0\n            -expandConnections 0\n            -showUpstreamCurves 1\n            -showUnitlessCurves 1\n            -showCompounds 1\n            -showLeafs 1\n            -showNumericAttrsOnly 0\n            -highlightActive 1\n            -autoSelectNewObjects 0\n            -doNotSelectNewObjects 0\n            -dropIsParent 1\n            -transmitFilters 0\n            -setFilter \"defaultSetFilter\" \n            -showSetMembers 1\n            -allowMultiSelection 1\n            -alwaysToggleSelect 0\n            -directSelect 0\n            -isSet 0\n            -isSetMember 0\n"
		+ "            -displayMode \"DAG\" \n            -expandObjects 0\n            -setsIgnoreFilters 1\n            -containersIgnoreFilters 0\n            -editAttrName 0\n            -showAttrValues 0\n            -highlightSecondary 0\n            -showUVAttrsOnly 0\n            -showTextureNodesOnly 0\n            -attrAlphaOrder \"default\" \n            -animLayerFilterOptions \"allAffecting\" \n            -sortOrder \"none\" \n            -longNames 0\n            -niceNames 1\n            -showNamespace 1\n            -showPinIcons 0\n            -mapMotionTrails 0\n            -ignoreHiddenAttribute 0\n            -ignoreOutlinerColor 0\n            -renderFilterVisible 0\n            -renderFilterIndex 0\n            -selectionOrder \"chronological\" \n            -expandAttribute 0\n            $editorName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextPanel \"outlinerPanel\" (localizedPanelLabel(\"Outliner\")) `;\n\tif (\"\" != $panelName) {\n\t\t$label = `panel -q -label $panelName`;\n"
		+ "\t\toutlinerPanel -edit -l (localizedPanelLabel(\"Outliner\")) -mbv $menusOkayInPanels  $panelName;\n\t\t$editorName = $panelName;\n        outlinerEditor -e \n            -showShapes 0\n            -showAssignedMaterials 0\n            -showTimeEditor 1\n            -showReferenceNodes 0\n            -showReferenceMembers 0\n            -showAttributes 0\n            -showConnected 0\n            -showAnimCurvesOnly 0\n            -showMuteInfo 0\n            -organizeByLayer 1\n            -organizeByClip 1\n            -showAnimLayerWeight 1\n            -autoExpandLayers 1\n            -autoExpand 0\n            -showDagOnly 1\n            -showAssets 1\n            -showContainedOnly 1\n            -showPublishedAsConnected 0\n            -showParentContainers 0\n            -showContainerContents 1\n            -ignoreDagHierarchy 0\n            -expandConnections 0\n            -showUpstreamCurves 1\n            -showUnitlessCurves 1\n            -showCompounds 1\n            -showLeafs 1\n            -showNumericAttrsOnly 0\n            -highlightActive 1\n"
		+ "            -autoSelectNewObjects 0\n            -doNotSelectNewObjects 0\n            -dropIsParent 1\n            -transmitFilters 0\n            -setFilter \"0\" \n            -showSetMembers 1\n            -allowMultiSelection 1\n            -alwaysToggleSelect 0\n            -directSelect 0\n            -displayMode \"DAG\" \n            -expandObjects 0\n            -setsIgnoreFilters 1\n            -containersIgnoreFilters 0\n            -editAttrName 0\n            -showAttrValues 0\n            -highlightSecondary 0\n            -showUVAttrsOnly 0\n            -showTextureNodesOnly 0\n            -attrAlphaOrder \"default\" \n            -animLayerFilterOptions \"allAffecting\" \n            -sortOrder \"none\" \n            -longNames 0\n            -niceNames 1\n            -showNamespace 1\n            -showPinIcons 0\n            -mapMotionTrails 0\n            -ignoreHiddenAttribute 0\n            -ignoreOutlinerColor 0\n            -renderFilterVisible 0\n            $editorName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n"
		+ "\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"graphEditor\" (localizedPanelLabel(\"Graph Editor\")) `;\n\tif (\"\" != $panelName) {\n\t\t$label = `panel -q -label $panelName`;\n\t\tscriptedPanel -edit -l (localizedPanelLabel(\"Graph Editor\")) -mbv $menusOkayInPanels  $panelName;\n\n\t\t\t$editorName = ($panelName+\"OutlineEd\");\n            outlinerEditor -e \n                -showShapes 1\n                -showAssignedMaterials 0\n                -showTimeEditor 1\n                -showReferenceNodes 0\n                -showReferenceMembers 0\n                -showAttributes 1\n                -showConnected 1\n                -showAnimCurvesOnly 1\n                -showMuteInfo 0\n                -organizeByLayer 1\n                -organizeByClip 1\n                -showAnimLayerWeight 1\n                -autoExpandLayers 1\n                -autoExpand 1\n                -showDagOnly 0\n                -showAssets 1\n                -showContainedOnly 0\n                -showPublishedAsConnected 0\n                -showParentContainers 1\n"
		+ "                -showContainerContents 0\n                -ignoreDagHierarchy 0\n                -expandConnections 1\n                -showUpstreamCurves 1\n                -showUnitlessCurves 1\n                -showCompounds 0\n                -showLeafs 1\n                -showNumericAttrsOnly 1\n                -highlightActive 0\n                -autoSelectNewObjects 1\n                -doNotSelectNewObjects 0\n                -dropIsParent 1\n                -transmitFilters 1\n                -setFilter \"0\" \n                -showSetMembers 0\n                -allowMultiSelection 1\n                -alwaysToggleSelect 0\n                -directSelect 0\n                -displayMode \"DAG\" \n                -expandObjects 0\n                -setsIgnoreFilters 1\n                -containersIgnoreFilters 0\n                -editAttrName 0\n                -showAttrValues 0\n                -highlightSecondary 0\n                -showUVAttrsOnly 0\n                -showTextureNodesOnly 0\n                -attrAlphaOrder \"default\" \n                -animLayerFilterOptions \"allAffecting\" \n"
		+ "                -sortOrder \"none\" \n                -longNames 0\n                -niceNames 1\n                -showNamespace 1\n                -showPinIcons 1\n                -mapMotionTrails 1\n                -ignoreHiddenAttribute 0\n                -ignoreOutlinerColor 0\n                -renderFilterVisible 0\n                $editorName;\n\n\t\t\t$editorName = ($panelName+\"GraphEd\");\n            animCurveEditor -e \n                -displayKeys 1\n                -displayTangents 0\n                -displayActiveKeys 0\n                -displayActiveKeyTangents 1\n                -displayInfinities 0\n                -displayValues 0\n                -autoFit 1\n                -snapTime \"integer\" \n                -snapValue \"none\" \n                -showResults \"off\" \n                -showBufferCurves \"off\" \n                -smoothness \"fine\" \n                -resultSamples 1\n                -resultScreenSamples 0\n                -resultUpdate \"delayed\" \n                -showUpstreamCurves 1\n                -showCurveNames 0\n"
		+ "                -showActiveCurveNames 0\n                -stackedCurves 0\n                -stackedCurvesMin -1\n                -stackedCurvesMax 1\n                -stackedCurvesSpace 0.2\n                -displayNormalized 0\n                -preSelectionHighlight 0\n                -constrainDrag 0\n                -classicMode 1\n                -valueLinesToggle 1\n                $editorName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"dopeSheetPanel\" (localizedPanelLabel(\"Dope Sheet\")) `;\n\tif (\"\" != $panelName) {\n\t\t$label = `panel -q -label $panelName`;\n\t\tscriptedPanel -edit -l (localizedPanelLabel(\"Dope Sheet\")) -mbv $menusOkayInPanels  $panelName;\n\n\t\t\t$editorName = ($panelName+\"OutlineEd\");\n            outlinerEditor -e \n                -showShapes 1\n                -showAssignedMaterials 0\n                -showTimeEditor 1\n                -showReferenceNodes 0\n                -showReferenceMembers 0\n                -showAttributes 1\n"
		+ "                -showConnected 1\n                -showAnimCurvesOnly 1\n                -showMuteInfo 0\n                -organizeByLayer 1\n                -organizeByClip 1\n                -showAnimLayerWeight 1\n                -autoExpandLayers 1\n                -autoExpand 0\n                -showDagOnly 0\n                -showAssets 1\n                -showContainedOnly 0\n                -showPublishedAsConnected 0\n                -showParentContainers 1\n                -showContainerContents 0\n                -ignoreDagHierarchy 0\n                -expandConnections 1\n                -showUpstreamCurves 1\n                -showUnitlessCurves 0\n                -showCompounds 1\n                -showLeafs 1\n                -showNumericAttrsOnly 1\n                -highlightActive 0\n                -autoSelectNewObjects 0\n                -doNotSelectNewObjects 1\n                -dropIsParent 1\n                -transmitFilters 0\n                -setFilter \"0\" \n                -showSetMembers 0\n                -allowMultiSelection 1\n"
		+ "                -alwaysToggleSelect 0\n                -directSelect 0\n                -displayMode \"DAG\" \n                -expandObjects 0\n                -setsIgnoreFilters 1\n                -containersIgnoreFilters 0\n                -editAttrName 0\n                -showAttrValues 0\n                -highlightSecondary 0\n                -showUVAttrsOnly 0\n                -showTextureNodesOnly 0\n                -attrAlphaOrder \"default\" \n                -animLayerFilterOptions \"allAffecting\" \n                -sortOrder \"none\" \n                -longNames 0\n                -niceNames 1\n                -showNamespace 1\n                -showPinIcons 0\n                -mapMotionTrails 1\n                -ignoreHiddenAttribute 0\n                -ignoreOutlinerColor 0\n                -renderFilterVisible 0\n                $editorName;\n\n\t\t\t$editorName = ($panelName+\"DopeSheetEd\");\n            dopeSheetEditor -e \n                -displayKeys 1\n                -displayTangents 0\n                -displayActiveKeys 0\n                -displayActiveKeyTangents 0\n"
		+ "                -displayInfinities 0\n                -displayValues 0\n                -autoFit 0\n                -snapTime \"integer\" \n                -snapValue \"none\" \n                -outliner \"dopeSheetPanel1OutlineEd\" \n                -showSummary 1\n                -showScene 0\n                -hierarchyBelow 0\n                -showTicks 1\n                -selectionWindow 0 0 0 0 \n                $editorName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"timeEditorPanel\" (localizedPanelLabel(\"Time Editor\")) `;\n\tif (\"\" != $panelName) {\n\t\t$label = `panel -q -label $panelName`;\n\t\tscriptedPanel -edit -l (localizedPanelLabel(\"Time Editor\")) -mbv $menusOkayInPanels  $panelName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"clipEditorPanel\" (localizedPanelLabel(\"Trax Editor\")) `;\n\tif (\"\" != $panelName) {\n\t\t$label = `panel -q -label $panelName`;\n\t\tscriptedPanel -edit -l (localizedPanelLabel(\"Trax Editor\")) -mbv $menusOkayInPanels  $panelName;\n"
		+ "\n\t\t\t$editorName = clipEditorNameFromPanel($panelName);\n            clipEditor -e \n                -displayKeys 0\n                -displayTangents 0\n                -displayActiveKeys 0\n                -displayActiveKeyTangents 0\n                -displayInfinities 0\n                -displayValues 0\n                -autoFit 0\n                -snapTime \"none\" \n                -snapValue \"none\" \n                -initialized 0\n                -manageSequencer 0 \n                $editorName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"sequenceEditorPanel\" (localizedPanelLabel(\"Camera Sequencer\")) `;\n\tif (\"\" != $panelName) {\n\t\t$label = `panel -q -label $panelName`;\n\t\tscriptedPanel -edit -l (localizedPanelLabel(\"Camera Sequencer\")) -mbv $menusOkayInPanels  $panelName;\n\n\t\t\t$editorName = sequenceEditorNameFromPanel($panelName);\n            clipEditor -e \n                -displayKeys 0\n                -displayTangents 0\n                -displayActiveKeys 0\n"
		+ "                -displayActiveKeyTangents 0\n                -displayInfinities 0\n                -displayValues 0\n                -autoFit 0\n                -snapTime \"none\" \n                -snapValue \"none\" \n                -initialized 0\n                -manageSequencer 1 \n                $editorName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"hyperGraphPanel\" (localizedPanelLabel(\"Hypergraph Hierarchy\")) `;\n\tif (\"\" != $panelName) {\n\t\t$label = `panel -q -label $panelName`;\n\t\tscriptedPanel -edit -l (localizedPanelLabel(\"Hypergraph Hierarchy\")) -mbv $menusOkayInPanels  $panelName;\n\n\t\t\t$editorName = ($panelName+\"HyperGraphEd\");\n            hyperGraph -e \n                -graphLayoutStyle \"hierarchicalLayout\" \n                -orientation \"horiz\" \n                -mergeConnections 0\n                -zoom 1\n                -animateTransition 0\n                -showRelationships 1\n                -showShapes 0\n                -showDeformers 0\n"
		+ "                -showExpressions 0\n                -showConstraints 0\n                -showConnectionFromSelected 0\n                -showConnectionToSelected 0\n                -showConstraintLabels 0\n                -showUnderworld 0\n                -showInvisible 0\n                -transitionFrames 1\n                -opaqueContainers 0\n                -freeform 0\n                -imagePosition 0 0 \n                -imageScale 1\n                -imageEnabled 0\n                -graphType \"DAG\" \n                -heatMapDisplay 0\n                -updateSelection 1\n                -updateNodeAdded 1\n                -useDrawOverrideColor 0\n                -limitGraphTraversal -1\n                -range 0 0 \n                -iconSize \"smallIcons\" \n                -showCachedConnections 0\n                $editorName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"hyperShadePanel\" (localizedPanelLabel(\"Hypershade\")) `;\n\tif (\"\" != $panelName) {\n"
		+ "\t\t$label = `panel -q -label $panelName`;\n\t\tscriptedPanel -edit -l (localizedPanelLabel(\"Hypershade\")) -mbv $menusOkayInPanels  $panelName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"visorPanel\" (localizedPanelLabel(\"Visor\")) `;\n\tif (\"\" != $panelName) {\n\t\t$label = `panel -q -label $panelName`;\n\t\tscriptedPanel -edit -l (localizedPanelLabel(\"Visor\")) -mbv $menusOkayInPanels  $panelName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"nodeEditorPanel\" (localizedPanelLabel(\"Node Editor\")) `;\n\tif (\"\" != $panelName) {\n\t\t$label = `panel -q -label $panelName`;\n\t\tscriptedPanel -edit -l (localizedPanelLabel(\"Node Editor\")) -mbv $menusOkayInPanels  $panelName;\n\n\t\t\t$editorName = ($panelName+\"NodeEditorEd\");\n            nodeEditor -e \n                -allAttributes 0\n                -allNodes 0\n                -autoSizeNodes 1\n                -consistentNameSize 1\n                -createNodeCommand \"nodeEdCreateNodeCommand\" \n"
		+ "                -connectNodeOnCreation 0\n                -connectOnDrop 0\n                -highlightConnections 0\n                -copyConnectionsOnPaste 0\n                -defaultPinnedState 0\n                -additiveGraphingMode 0\n                -settingsChangedCallback \"nodeEdSyncControls\" \n                -traversalDepthLimit -1\n                -keyPressCommand \"nodeEdKeyPressCommand\" \n                -nodeTitleMode \"name\" \n                -gridSnap 0\n                -gridVisibility 1\n                -crosshairOnEdgeDragging 0\n                -popupMenuScript \"nodeEdBuildPanelMenus\" \n                -showNamespace 1\n                -showShapes 1\n                -showSGShapes 0\n                -showTransforms 1\n                -useAssets 1\n                -syncedSelection 1\n                -extendToShapes 1\n                -activeTab -1\n                -editorMode \"default\" \n                $editorName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"createNodePanel\" (localizedPanelLabel(\"Create Node\")) `;\n"
		+ "\tif (\"\" != $panelName) {\n\t\t$label = `panel -q -label $panelName`;\n\t\tscriptedPanel -edit -l (localizedPanelLabel(\"Create Node\")) -mbv $menusOkayInPanels  $panelName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"polyTexturePlacementPanel\" (localizedPanelLabel(\"UV Editor\")) `;\n\tif (\"\" != $panelName) {\n\t\t$label = `panel -q -label $panelName`;\n\t\tscriptedPanel -edit -l (localizedPanelLabel(\"UV Editor\")) -mbv $menusOkayInPanels  $panelName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"renderWindowPanel\" (localizedPanelLabel(\"Render View\")) `;\n\tif (\"\" != $panelName) {\n\t\t$label = `panel -q -label $panelName`;\n\t\tscriptedPanel -edit -l (localizedPanelLabel(\"Render View\")) -mbv $menusOkayInPanels  $panelName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextPanel \"shapePanel\" (localizedPanelLabel(\"Shape Editor\")) `;\n"
		+ "\tif (\"\" != $panelName) {\n\t\t$label = `panel -q -label $panelName`;\n\t\tshapePanel -edit -l (localizedPanelLabel(\"Shape Editor\")) -mbv $menusOkayInPanels  $panelName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextPanel \"posePanel\" (localizedPanelLabel(\"Pose Editor\")) `;\n\tif (\"\" != $panelName) {\n\t\t$label = `panel -q -label $panelName`;\n\t\tposePanel -edit -l (localizedPanelLabel(\"Pose Editor\")) -mbv $menusOkayInPanels  $panelName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"dynRelEdPanel\" (localizedPanelLabel(\"Dynamic Relationships\")) `;\n\tif (\"\" != $panelName) {\n\t\t$label = `panel -q -label $panelName`;\n\t\tscriptedPanel -edit -l (localizedPanelLabel(\"Dynamic Relationships\")) -mbv $menusOkayInPanels  $panelName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"relationshipPanel\" (localizedPanelLabel(\"Relationship Editor\")) `;\n"
		+ "\tif (\"\" != $panelName) {\n\t\t$label = `panel -q -label $panelName`;\n\t\tscriptedPanel -edit -l (localizedPanelLabel(\"Relationship Editor\")) -mbv $menusOkayInPanels  $panelName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"referenceEditorPanel\" (localizedPanelLabel(\"Reference Editor\")) `;\n\tif (\"\" != $panelName) {\n\t\t$label = `panel -q -label $panelName`;\n\t\tscriptedPanel -edit -l (localizedPanelLabel(\"Reference Editor\")) -mbv $menusOkayInPanels  $panelName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"componentEditorPanel\" (localizedPanelLabel(\"Component Editor\")) `;\n\tif (\"\" != $panelName) {\n\t\t$label = `panel -q -label $panelName`;\n\t\tscriptedPanel -edit -l (localizedPanelLabel(\"Component Editor\")) -mbv $menusOkayInPanels  $panelName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"dynPaintScriptedPanelType\" (localizedPanelLabel(\"Paint Effects\")) `;\n"
		+ "\tif (\"\" != $panelName) {\n\t\t$label = `panel -q -label $panelName`;\n\t\tscriptedPanel -edit -l (localizedPanelLabel(\"Paint Effects\")) -mbv $menusOkayInPanels  $panelName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"scriptEditorPanel\" (localizedPanelLabel(\"Script Editor\")) `;\n\tif (\"\" != $panelName) {\n\t\t$label = `panel -q -label $panelName`;\n\t\tscriptedPanel -edit -l (localizedPanelLabel(\"Script Editor\")) -mbv $menusOkayInPanels  $panelName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"profilerPanel\" (localizedPanelLabel(\"Profiler Tool\")) `;\n\tif (\"\" != $panelName) {\n\t\t$label = `panel -q -label $panelName`;\n\t\tscriptedPanel -edit -l (localizedPanelLabel(\"Profiler Tool\")) -mbv $menusOkayInPanels  $panelName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"contentBrowserPanel\" (localizedPanelLabel(\"Content Browser\")) `;\n"
		+ "\tif (\"\" != $panelName) {\n\t\t$label = `panel -q -label $panelName`;\n\t\tscriptedPanel -edit -l (localizedPanelLabel(\"Content Browser\")) -mbv $menusOkayInPanels  $panelName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\tif ($useSceneConfig) {\n        string $configName = `getPanel -cwl (localizedPanelLabel(\"Current Layout\"))`;\n        if (\"\" != $configName) {\n\t\t\tpanelConfiguration -edit -label (localizedPanelLabel(\"Current Layout\")) \n\t\t\t\t-userCreated false\n\t\t\t\t-defaultImage \"\"\n\t\t\t\t-image \"\"\n\t\t\t\t-sc false\n\t\t\t\t-configString \"global string $gMainPane; paneLayout -e -cn \\\"single\\\" -ps 1 100 100 $gMainPane;\"\n\t\t\t\t-removeAllPanels\n\t\t\t\t-ap false\n\t\t\t\t\t(localizedPanelLabel(\"Persp View\")) \n\t\t\t\t\t\"modelPanel\"\n"
		+ "\t\t\t\t\t\"$panelName = `modelPanel -unParent -l (localizedPanelLabel(\\\"Persp View\\\")) -mbv $menusOkayInPanels `;\\n$editorName = $panelName;\\nmodelEditor -e \\n    -cam `findStartUpCamera persp` \\n    -useInteractiveMode 0\\n    -displayLights \\\"default\\\" \\n    -displayAppearance \\\"smoothShaded\\\" \\n    -activeOnly 0\\n    -ignorePanZoom 0\\n    -wireframeOnShaded 0\\n    -headsUpDisplay 1\\n    -holdOuts 1\\n    -selectionHiliteDisplay 1\\n    -useDefaultMaterial 0\\n    -bufferMode \\\"double\\\" \\n    -twoSidedLighting 0\\n    -backfaceCulling 0\\n    -xray 0\\n    -jointXray 0\\n    -activeComponentsXray 0\\n    -displayTextures 0\\n    -smoothWireframe 0\\n    -lineWidth 1\\n    -textureAnisotropic 0\\n    -textureHilight 1\\n    -textureSampling 2\\n    -textureDisplay \\\"modulate\\\" \\n    -textureMaxSize 16384\\n    -fogging 0\\n    -fogSource \\\"fragment\\\" \\n    -fogMode \\\"linear\\\" \\n    -fogStart 0\\n    -fogEnd 100\\n    -fogDensity 0.1\\n    -fogColor 0.5 0.5 0.5 1 \\n    -depthOfFieldPreview 1\\n    -maxConstantTransparency 1\\n    -rendererName \\\"vp2Renderer\\\" \\n    -objectFilterShowInHUD 1\\n    -isFiltered 0\\n    -colorResolution 256 256 \\n    -bumpResolution 512 512 \\n    -textureCompression 0\\n    -transparencyAlgorithm \\\"frontAndBackCull\\\" \\n    -transpInShadows 0\\n    -cullingOverride \\\"none\\\" \\n    -lowQualityLighting 0\\n    -maximumNumHardwareLights 1\\n    -occlusionCulling 0\\n    -shadingModel 0\\n    -useBaseRenderer 0\\n    -useReducedRenderer 0\\n    -smallObjectCulling 0\\n    -smallObjectThreshold -1 \\n    -interactiveDisableShadows 0\\n    -interactiveBackFaceCull 0\\n    -sortTransparent 1\\n    -controllers 1\\n    -nurbsCurves 1\\n    -nurbsSurfaces 1\\n    -polymeshes 1\\n    -subdivSurfaces 1\\n    -planes 1\\n    -lights 1\\n    -cameras 1\\n    -controlVertices 1\\n    -hulls 1\\n    -grid 1\\n    -imagePlane 1\\n    -joints 1\\n    -ikHandles 1\\n    -deformers 1\\n    -dynamics 1\\n    -particleInstancers 1\\n    -fluids 1\\n    -hairSystems 1\\n    -follicles 1\\n    -nCloths 1\\n    -nParticles 1\\n    -nRigids 1\\n    -dynamicConstraints 1\\n    -locators 1\\n    -manipulators 1\\n    -pluginShapes 1\\n    -dimensions 1\\n    -handles 1\\n    -pivots 1\\n    -textures 1\\n    -strokes 1\\n    -motionTrails 1\\n    -clipGhosts 1\\n    -greasePencils 1\\n    -shadows 0\\n    -captureSequenceNumber -1\\n    -width 1585\\n    -height 716\\n    -sceneRenderFilter 0\\n    $editorName;\\nmodelEditor -e -viewSelected 0 $editorName;\\nmodelEditor -e \\n    -pluginObjects \\\"gpuCacheDisplayFilter\\\" 1 \\n    $editorName\"\n"
		+ "\t\t\t\t\t\"modelPanel -edit -l (localizedPanelLabel(\\\"Persp View\\\")) -mbv $menusOkayInPanels  $panelName;\\n$editorName = $panelName;\\nmodelEditor -e \\n    -cam `findStartUpCamera persp` \\n    -useInteractiveMode 0\\n    -displayLights \\\"default\\\" \\n    -displayAppearance \\\"smoothShaded\\\" \\n    -activeOnly 0\\n    -ignorePanZoom 0\\n    -wireframeOnShaded 0\\n    -headsUpDisplay 1\\n    -holdOuts 1\\n    -selectionHiliteDisplay 1\\n    -useDefaultMaterial 0\\n    -bufferMode \\\"double\\\" \\n    -twoSidedLighting 0\\n    -backfaceCulling 0\\n    -xray 0\\n    -jointXray 0\\n    -activeComponentsXray 0\\n    -displayTextures 0\\n    -smoothWireframe 0\\n    -lineWidth 1\\n    -textureAnisotropic 0\\n    -textureHilight 1\\n    -textureSampling 2\\n    -textureDisplay \\\"modulate\\\" \\n    -textureMaxSize 16384\\n    -fogging 0\\n    -fogSource \\\"fragment\\\" \\n    -fogMode \\\"linear\\\" \\n    -fogStart 0\\n    -fogEnd 100\\n    -fogDensity 0.1\\n    -fogColor 0.5 0.5 0.5 1 \\n    -depthOfFieldPreview 1\\n    -maxConstantTransparency 1\\n    -rendererName \\\"vp2Renderer\\\" \\n    -objectFilterShowInHUD 1\\n    -isFiltered 0\\n    -colorResolution 256 256 \\n    -bumpResolution 512 512 \\n    -textureCompression 0\\n    -transparencyAlgorithm \\\"frontAndBackCull\\\" \\n    -transpInShadows 0\\n    -cullingOverride \\\"none\\\" \\n    -lowQualityLighting 0\\n    -maximumNumHardwareLights 1\\n    -occlusionCulling 0\\n    -shadingModel 0\\n    -useBaseRenderer 0\\n    -useReducedRenderer 0\\n    -smallObjectCulling 0\\n    -smallObjectThreshold -1 \\n    -interactiveDisableShadows 0\\n    -interactiveBackFaceCull 0\\n    -sortTransparent 1\\n    -controllers 1\\n    -nurbsCurves 1\\n    -nurbsSurfaces 1\\n    -polymeshes 1\\n    -subdivSurfaces 1\\n    -planes 1\\n    -lights 1\\n    -cameras 1\\n    -controlVertices 1\\n    -hulls 1\\n    -grid 1\\n    -imagePlane 1\\n    -joints 1\\n    -ikHandles 1\\n    -deformers 1\\n    -dynamics 1\\n    -particleInstancers 1\\n    -fluids 1\\n    -hairSystems 1\\n    -follicles 1\\n    -nCloths 1\\n    -nParticles 1\\n    -nRigids 1\\n    -dynamicConstraints 1\\n    -locators 1\\n    -manipulators 1\\n    -pluginShapes 1\\n    -dimensions 1\\n    -handles 1\\n    -pivots 1\\n    -textures 1\\n    -strokes 1\\n    -motionTrails 1\\n    -clipGhosts 1\\n    -greasePencils 1\\n    -shadows 0\\n    -captureSequenceNumber -1\\n    -width 1585\\n    -height 716\\n    -sceneRenderFilter 0\\n    $editorName;\\nmodelEditor -e -viewSelected 0 $editorName;\\nmodelEditor -e \\n    -pluginObjects \\\"gpuCacheDisplayFilter\\\" 1 \\n    $editorName\"\n"
		+ "\t\t\t\t$configName;\n\n            setNamedPanelLayout (localizedPanelLabel(\"Current Layout\"));\n        }\n\n        panelHistory -e -clear mainPanelHistory;\n        sceneUIReplacement -clear;\n\t}\n\n\ngrid -spacing 5 -size 12 -divisions 5 -displayAxes yes -displayGridLines yes -displayDivisionLines yes -displayPerspectiveLabels no -displayOrthographicLabels no -displayAxesBold yes -perspectiveLabelPosition axis -orthographicLabelPosition edge;\nviewManip -drawCompass 0 -compassAngle 0 -frontParameters \"\" -homeParameters \"\" -selectionLockParameters \"\";\n}\n");
	setAttr ".st" 3;
createNode script -n "sceneConfigurationScriptNode";
	rename -uid "ADEE2C30-429C-C9B4-48D9-6FA54FA4AEC8";
	setAttr ".b" -type "string" "playbackOptions -min 1 -max 120 -ast 1 -aet 200 ";
	setAttr ".st" 6;
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
	setAttr ".ro" yes;
select -ne :initialParticleSE;
	setAttr ".ro" yes;
select -ne :defaultRenderGlobals;
	setAttr ".ren" -type "string" "arnold";
select -ne :defaultResolution;
	setAttr ".pa" 1;
select -ne :hardwareRenderGlobals;
	setAttr ".ctrs" 256;
	setAttr ".btrs" 512;
select -ne :ikSystem;
	setAttr -s 4 ".sol";
connectAttr "polySplit37.out" "pCubeShape1.i";
relationship "link" ":lightLinker1" ":initialShadingGroup.message" ":defaultLightSet.message";
relationship "link" ":lightLinker1" ":initialParticleSE.message" ":defaultLightSet.message";
relationship "shadowLink" ":lightLinker1" ":initialShadingGroup.message" ":defaultLightSet.message";
relationship "shadowLink" ":lightLinker1" ":initialParticleSE.message" ":defaultLightSet.message";
connectAttr "layerManager.dli[0]" "defaultLayer.id";
connectAttr "renderLayerManager.rlmi[0]" "defaultRenderLayer.rlid";
connectAttr "polyCube1.out" "polySplit1.ip";
connectAttr "polySplit1.out" "polySplit2.ip";
connectAttr "polySplit2.out" "polySplit3.ip";
connectAttr "polySplit3.out" "polySplit4.ip";
connectAttr "polySplit4.out" "polySplit5.ip";
connectAttr "polySplit5.out" "polySplit6.ip";
connectAttr "polySplit6.out" "polySplit7.ip";
connectAttr "polySplit7.out" "polySplit8.ip";
connectAttr "polySplit8.out" "polySplit9.ip";
connectAttr "polySplit9.out" "polySplit10.ip";
connectAttr "polySplit10.out" "polySplit11.ip";
connectAttr "polySplit11.out" "polySplit12.ip";
connectAttr "polySplit12.out" "polySplit13.ip";
connectAttr "polySplit13.out" "polySplit14.ip";
connectAttr "polySplit14.out" "polySplit15.ip";
connectAttr "polySplit15.out" "polySplit16.ip";
connectAttr "polyTweak1.out" "polyExtrudeFace1.ip";
connectAttr "pCubeShape1.wm" "polyExtrudeFace1.mp";
connectAttr "polySplit16.out" "polyTweak1.ip";
connectAttr "polyTweak2.out" "polyBevel1.ip";
connectAttr "pCubeShape1.wm" "polyBevel1.mp";
connectAttr "polyExtrudeFace1.out" "polyTweak2.ip";
connectAttr "polyBevel1.out" "polyBevel2.ip";
connectAttr "pCubeShape1.wm" "polyBevel2.mp";
connectAttr "polyTweak3.out" "polyBevel3.ip";
connectAttr "pCubeShape1.wm" "polyBevel3.mp";
connectAttr "polyBevel2.out" "polyTweak3.ip";
connectAttr "polyBevel3.out" "polyBevel4.ip";
connectAttr "pCubeShape1.wm" "polyBevel4.mp";
connectAttr "polyBevel4.out" "polyBevel5.ip";
connectAttr "pCubeShape1.wm" "polyBevel5.mp";
connectAttr "polyBevel5.out" "polyBevel6.ip";
connectAttr "pCubeShape1.wm" "polyBevel6.mp";
connectAttr "polyBevel6.out" "polyBevel7.ip";
connectAttr "pCubeShape1.wm" "polyBevel7.mp";
connectAttr "polyBevel7.out" "polyTweak4.ip";
connectAttr "polyTweak4.out" "polySplit17.ip";
connectAttr "polySplit17.out" "polySplit18.ip";
connectAttr "polySplit18.out" "polySplit19.ip";
connectAttr "polySplit19.out" "polySplit20.ip";
connectAttr "polySplit20.out" "polySplit21.ip";
connectAttr "polySplit21.out" "polySplit22.ip";
connectAttr "polySplit22.out" "polySplit23.ip";
connectAttr "polySplit23.out" "polySplit24.ip";
connectAttr "polySplit24.out" "polySplit25.ip";
connectAttr "polySplit25.out" "polySplit26.ip";
connectAttr "polySplit26.out" "polySplit27.ip";
connectAttr "polySplit27.out" "polySplit28.ip";
connectAttr "polySplit28.out" "polySplit29.ip";
connectAttr "polySplit29.out" "polySplit30.ip";
connectAttr "polySplit30.out" "polySplit31.ip";
connectAttr "polySplit31.out" "polySplit32.ip";
connectAttr "polySplit32.out" "polySplit33.ip";
connectAttr "polySplit33.out" "polySplit34.ip";
connectAttr "polySplit34.out" "polySplit35.ip";
connectAttr "polySplit35.out" "polyTweak5.ip";
connectAttr "polyTweak5.out" "deleteComponent1.ig";
connectAttr "deleteComponent1.og" "deleteComponent2.ig";
connectAttr "polyTweak6.out" "polyMergeVert1.ip";
connectAttr "pCubeShape1.wm" "polyMergeVert1.mp";
connectAttr "deleteComponent2.og" "polyTweak6.ip";
connectAttr "polyTweak7.out" "polyMergeVert2.ip";
connectAttr "pCubeShape1.wm" "polyMergeVert2.mp";
connectAttr "polyMergeVert1.out" "polyTweak7.ip";
connectAttr "polyMergeVert2.out" "polyTweak8.ip";
connectAttr "polyTweak8.out" "polySplit36.ip";
connectAttr "polySplit36.out" "polySplit37.ip";
connectAttr "defaultRenderLayer.msg" ":defaultRenderingList1.r" -na;
connectAttr "pCubeShape1.iog" ":initialShadingGroup.dsm" -na;
// End of Environment.ma
