$title = "acc1"
$page="https://plus.google.com/+Dichthuatdonga"
HotKeySet("{ESC}", "King")
Local  $sx=0;-1366
Local  $sy=0
Local $numberLoop=0
Local $numberAdd=0
Local $numberComment=0
Func King()
	Exit
 EndFunc
Func GetAddBtnPixel($gx)
	  ; 453 510 ; 450, 513 ; 457, 513 ; 453, 517 553, 573
	  $aCoord1 =  PixelSearch($gx, 130, $gx, 730 , 0x676767)
	  If Not @error Then
		 Sleep(200)
		 If((PixelGetColor($aCoord1[0]-2,$aCoord1[1]) = 16777215) and (PixelGetColor($aCoord1[0]+3,$aCoord1[1]-3) = 6776679) and (PixelGetColor($aCoord1[0]+6,$aCoord1[1]) = 6776679) and (PixelGetColor($aCoord1[0]+3,$aCoord1[1]+3) = 6776679)) Then
			MouseMove ($aCoord1[0],$aCoord1[1])
			Return $aCoord1
		 EndIf
	  EndIf
		Return Null
EndFunc
Func FFIsLoaded()
   $isloaded=True;
   While $isloaded
	  Sleep(1000)
	  if(PixelGetColor(54, 115) = 11810085) Then;loaded
		 $isloaded=False
	  EndIf
   WEnd
EndFunc

Func AddCircle()
		 Sleep(100)
		 MouseMove(433, 514, 1)
		 Sleep(500)
		 MouseMove(409, 605, 1)
		 Sleep(100)
		 MouseClick("left",409, 605, 1)
EndFunc

Func AutoAdd($x)
   Sleep(100)
	  $aCoord1 = GetAddBtnPixel($sx+$x)
		If $aCoord1 <> Null Then
		   MouseMove($aCoord1[0], $aCoord1[1], 1)
		   Sleep(100)
		   MouseClick("left",$aCoord1[0], $aCoord1[1], 1)
		   Sleep(100);
		   $numberAdd=$numberAdd+1
		  If  ($numberComment = 0 ) And (PixelGetColor($aCoord1[0]+ 120,$aCoord1[1]-14) = 14540253) Then
			 MouseClick("left",$aCoord1[0]+120, $aCoord1[1], 1)
			 Sleep(500)
			 For $i = 1 To Random(1, 5, 1)
			   Sleep(10)
			Next
			Send("Vao cong giup minh nhe, thanks")
			Sleep(50)
				  Send("{TAB}")
				  Sleep(50)
				  Send("{SPACE}")
				  Sleep(500)
				  $numberComment=$numberComment+1
			EndIf
		  Sleep(100);
		EndIf
	 EndFunc

Sleep(1000);
MouseClick("left",54, 115, 1)
FFIsLoaded()
Sleep(100)
Send("{HOME}")
AddCircle()
Sleep(100)
While (($numberLoop<15) And ($numberAdd<20))
      Sleep(50);
	  $title = WinGetTitle("[active]")
	  If StringInStr($title, "Google+")>0 Then
	    Send("{PGDN}")
		$numberLoop=$numberLoop+1
	    Sleep(300);
		AutoAdd(340)
		AutoAdd(720)
	EndIf
WEnd
