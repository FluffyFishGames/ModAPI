                     HOW TO COMPILE
					 
  To compile the ModAPI in a way it is ready to operate you 
  have to take care of some things.
  
  1) You have to fix the assembly linkage to UnityEngine.dll
     in the BaseModLib project.
	 
  2) Build the BaseModLib project. This way there is a libs
     folder created inside the bin folder with the BaseModLib.dll,
	 System.Xml.Linq.dll and Ionic.Zip.dll. All of them are needed
	 to mod a game.
	 
  3) You are ready to go! Now you can compile the ModAPI project.