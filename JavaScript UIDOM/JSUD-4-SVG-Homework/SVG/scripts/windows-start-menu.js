(function () {
  	var builder = getSvgBuilder('http://www.w3.org/2000/svg');
  	var svg = document.getElementById('the-svg'); 

  	(function buildTitle () {
  		svg.appendChild(builder.text(70,70,'lightblue',40,'Start'));
  		svg.appendChild(builder.text(870,70,'lightblue',30,'Richard'));
  		svg.appendChild(builder.text(928,88,'lightblue',15,'Perry'));
  	}());

  	(function buildMainBlock () {
  		(function buildCol1 () {
  			svg.appendChild(builder.rect(70,140,100,100,'#3893ea'));
  			svg.appendChild(builder.text(85,230,'white',13,'Store'));
  			svg.appendChild(builder.image(90,150,60,60,'images/store.png'));

  			svg.appendChild(builder.rect(70,245,100,100,'#603CBB'));
  			svg.appendChild(builder.text(85,336,'white',13,'Maps'));
  			svg.appendChild(builder.image(90,260,60,60,'images/maps.png'));

  			svg.appendChild(builder.rect(175,140,100,100,'#93C92B'));
  			svg.appendChild(builder.text(180,230,'white',13,'Xbox Live Games'));
  			svg.appendChild(builder.image(195,155,60,60,'images/XboxLiveGames.png'));

  			svg.appendChild(builder.rect(175,245,100,100,'#3893ea'));
  			svg.appendChild(builder.text(180,336,'white',13,'Internet Explorer'));
  			svg.appendChild(builder.image(195,260,60,60,'images/ie.png'));

  			svg.appendChild(builder.rect(70,351,205,100,'#DD532E'));
  			svg.appendChild(builder.text(85,440,'white',13,'Video'));
  			svg.appendChild(builder.image(145,370,60,60,'images/video.png'));

  			svg.appendChild(builder.rect(70,457,205,100,'#29a09c'));
  			svg.appendChild(builder.text(85,545,'white',13,'Desktop'));
  			svg.appendChild(builder.image(130,460,80,80,'images/fish.png'));
  		}());

  		(function buildCol2 () {
  			svg.appendChild(builder.rect(280,140,205,100,'#B71C46'));
  			svg.appendChild(builder.text(295,230,'white',13,'Photos'));
  			svg.appendChild(builder.image(350,155,60,60,'images/photos.png'));

  			svg.appendChild(builder.rect(280,245,205,100,'#603CBB'));
  			svg.appendChild(builder.text(295,336,'white',13,'Messaging'));
  			svg.appendChild(builder.image(350,255,70,70,'images/messaging.png'));

  			svg.appendChild(builder.rect(280,351,205,100,'#009F19'));
  			svg.appendChild(builder.text(295,374,'white',18,'Devon Hypnotize'));
  			svg.appendChild(builder.text(295,388,'white',11,'something they can do about him'));
  			svg.appendChild(builder.text(295,402,'white',11,'pile of books and scroll next to'));
  			svg.appendChild(builder.text(295,442,'white',15,'3'));

  			svg.appendChild(builder.rect(280,457,205,100,'#3893ea'));
  			svg.appendChild(builder.text(295,545,'white',13,'Weather'));
  			svg.appendChild(builder.image(350,475,60,60,'images/weather.png'));
  		}());

  		(function buildCol3 () {
  			svg.appendChild(builder.rect(490,140,205,100,'#009F19'));
  			svg.appendChild(builder.text(507,230,'white',13,'Calendar'));
  			svg.appendChild(builder.text(622,190,'white',55,'12'));
  			svg.appendChild(builder.text(622,205,'white',13,'Monday'));

  			svg.appendChild(builder.rect(490,245,205,100,'#DD532E'));
  			svg.appendChild(builder.text(555,280,'white',13,'Mike Gibbs, Troll Scout'));
  			svg.appendChild(builder.text(555,290,'white',13,'and 5 others commented'));
  			svg.appendChild(builder.text(555,300,'white',13,'on your photo.'));
  			svg.appendChild(builder.image(500,265,55,55,'images/MikeGibbs.jpg'));

  			svg.appendChild(builder.rect(490,351,100,100,'#000000'));
  			svg.appendChild(builder.image(490,351,100,100,'images/pinball.png'));

  			svg.appendChild(builder.rect(595,351,100,100,'#3893ea'));
  			svg.appendChild(builder.text(610,440,'white',13,'Solitaire'));
  			svg.appendChild(builder.image(612,360,60,60,'images/solitaire.png'));

  			svg.appendChild(builder.rect(490,457,100,100,'#B71C46'));
  			svg.appendChild(builder.text(507,545,'white',13,'Camera'));
  			svg.appendChild(builder.image(514,475,55,55,'images/camera.png'));

  			svg.appendChild(builder.rect(595,457,100,100,'#3893ea'));
  			svg.appendChild(builder.text(602,545,'white',13,'Xbox Companion'));
  			svg.appendChild(builder.image(619,475,55,55,'images/xboxcom.png'));
  		}());
  	}());

  	(function buildSideBlock () {
  		(function buildCol1 () {
  			svg.appendChild(builder.rect(740,140,205,100,'#603CBB'));
  			svg.appendChild(builder.text(755,230,'white',13,'Music'));
  			svg.appendChild(builder.image(816,155,60,60,'images/music.png'));

  			svg.appendChild(builder.rect(740,245,205,100,'#009F19'));
  			svg.appendChild(builder.text(755,336,'white',13,'Finance'));
  			svg.appendChild(builder.image(816,260,50,50,'images/finance.png'));

  			svg.appendChild(builder.rect(740,351,100,100,'#DD532E'));
  			svg.appendChild(builder.text(755,440,'white',13,'Reader'));
  			svg.appendChild(builder.image(760,365,55,55,'images/reader.png'));

  			svg.appendChild(builder.rect(845,351,100,100,'#01296E'));
  			svg.appendChild(builder.text(860,380,'white',16,'Windows'));
  			svg.appendChild(builder.text(860,395,'white',16,'Explorer'));
  			svg.appendChild(builder.image(860,415,30,30,'images/WindowsExplorer.png'));
  		
  			svg.appendChild(builder.image(740,457,205,100,'images/WordPress.jpg'));
  		}());

  		(function buildCol2 () {
  			svg.appendChild(builder.rect(950,140,100,100,'#FFFFFF'));
  			svg.appendChild(builder.image(939,140,100,100,'images/2s.jpg'));

  			svg.appendChild(builder.rect(950,245,100,100,'#3d76ad'));
  			svg.appendChild(builder.image(965,260,65,65,'images/penguin.png'));

  			svg.appendChild(builder.rect(950,351,100,100,'#3893ea'));
  			svg.appendChild(builder.text(963,440,'white',13,'SkyDrive'));
  			svg.appendChild(builder.image(965,365,65,65,'images/skyDrive.png'));
  		}());
  	}());
}());



