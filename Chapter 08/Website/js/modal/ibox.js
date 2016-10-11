/********************************************************
For more info & download: http://www.ibegin.com/blog/p_ibox.html
Created for iBegin.com - local search done right
MIT Licensed Style
*********************************************************/
var indicator_img_path = "images/indicator.gif";
var indicator_img_html = "<img name=\"ibox_indicator\" src=\""+indicator_img_path+"\" alt=\"Loading...\" style=\"width:128px;height:128px;\"/>"; // don't remove the name


function init_ibox() {
	var elem_wrapper = "ibox";
	
	createIbox(document.getElementsByTagName("body")[0]); //create our ibox

	//	elements here start the look up from the start non <a> tags
	//var docRoot = (document.all) ? document.all : document.getElementsByTagName("*");
	
	// Or make sure we only check <a> tags
	var docRoot = document.getElementsByTagName("a");
	var ibAttr = "rel"; 	// our attribute identifier for our iBox elements

	var e;
	for (var i = 0; i < docRoot.length - 1; i++) {
			e = docRoot[i];
			if(e.getAttribute(ibAttr)) {
				var t = e.getAttribute(ibAttr);
				if ((t.indexOf("ibox") != -1)  ||  t.toLowerCase() == "ibox") { // check if this element is an iBox element
						e.onclick = function() { // rather assign an onclick event
							var t = this.getAttribute(ibAttr);
							var params = parseQuery(t.substr(5,999));
							var url = this.href;
							if(this.target != "") {url = this.target} 
							var title = this.title;
							showBG();
							showIbox(url,title,params);	// show ibox
							window.onscroll = maintPos;
							window.onresize = maintPos;
							return false;
						}; 
						
				}
			}
     }
}

showBG = function() {
	var box_w = getElem('ibox_w');

	var opacity_level = 8;
	box_w.style.opacity = 0;
	box_w.style.filter = 'alpha(opacity=0)';

	setBGOpacity = setOpacity;
	for (var i=0;i<=opacity_level;i++) {setTimeout("setIboxOpacity('ibox_w',"+i+")",70*i);} // from quirksmode.org
		
	box_w.style.display = "";
	var pagesize = new getPageSize();
	var scrollPos = new getScrollPos();
	var ua = navigator.userAgent;
	if(ua.indexOf("MSIE ") != -1) {box_w.style.width = pagesize.width+'px';} 
	else {box_w.style.width = pagesize.width-20+'px';}
	box_w.style.height = pagesize.height+scrollPos.scrollY+'px';
	selectVisibility("hidden");
}

/* Scrollbar hiding by Heidi http://liquidlead-art.com/ */
selectVisibility = function(v) {
	var selectElems = document.getElementsByTagName('select');	
	for(var i = 0; i < selectElems.length; ++i) {
		selectElems[i].style.visibility = v;
	}
}

hideBG = function() {
	var box_w = getElem('ibox_w');
	box_w.style.display = "none";
	selectVisibility("visible");
}

var loadCancelled = false;
showIndicator = function() {
	var ibox_p = getElem('ibox_progress');
	ibox_p.style.display = "";
	posToCenter(ibox_p);
	ibox_p.onclick = function() {hideIbox();hideIndicator();loadCancelled = true;}
}


hideIndicator = function() {
	var ibox_p = getElem('ibox_progress');
	ibox_p.style.display = "none";
	ibox_p.onclick = null;
}

createIbox = function(elem) {
	// a trick on just creating an ibox wrapper then doing an innerHTML on our root ibox element
	var strHTML = "<div id=\"ibox_w\" style=\"display:none;\"></div>";
	strHTML +=	"<div id=\"ibox_progress\" style=\"display:none;\">";
	strHTML +=  indicator_img_html;
	strHTML +=  "</div>";
	strHTML +=	"<div id=\"ibox_wrapper\" style=\"display:none\">";
	strHTML +=	"<div id=\"ibox_content\"></div>";
	strHTML +=	"<div id=\"ibox_footer_wrapper\"><div id=\"ibox_close\" style=\"float:right;\">";
	strHTML +=	"<a id=\"ibox_close_a\" href=\"javascript:void(null);\" >Click here to close</a></div>";
	strHTML +=  "<div id=\"ibox_footer\">&nbsp;</div></div></div></div>";

	var docBody = document.getElementsByTagName("body")[0];
	var ibox = document.createElement("div");
	ibox.setAttribute("id","ibox");
	ibox.style.display = '';
	ibox.innerHTML = strHTML;
	elem.appendChild(ibox);
}

var ibox_w_height = 0;
showIbox = function(url,title,params) {
var ibox = getElem('ibox_wrapper');
var ibox_type = 0;
												
	// set title here
	var ibox_footer = getElem('ibox_footer');
	if(title != "") {ibox_footer.innerHTML = title;} else {ibox_footer.innerHTML = "&nbsp;";}

	url = url.toLowerCase(); // have to lowercase
	
	// file checking code borrowed from thickbox
	var urlString = /\.jpg|\.jpeg|\.png|\.gif|\.html|\.htm|\.php|\.cfm|\.asp|\.aspx|\.jsp|\.jst|\.rb|\.txt/g;
	var urlType = url.match(urlString);
	
	if(urlType == '.jpg' || urlType == '.jpeg' || urlType == '.png' || urlType == '.gif'){
		ibox_type = 0;

		
		showIndicator();
		
		var imgPreloader = new Image();
		
		imgPreloader.onload = function(){

			imgPreloader = resizeImageToScreen(imgPreloader);
			hideIndicator();

			getElem('ibox_content').style.overflow = "hidden";

			var strHTML = "<a href=\"javascript:void(null);\"><img name=\"ibox_img\" src=\""+url+"\" style=\"width:"+imgPreloader.width+"px;height:"+imgPreloader.height+"px;border:0;\"/></a>";
			
			if(loadCancelled == false) {
				// set width and height
				ibox.style.height = imgPreloader.height+'px';
				ibox.style.width = imgPreloader.width+'px';
				ibox.style.display = "";
				ibox.style.visibility = "hidden";
				posToCenter(ibox); 	
				ibox.style.visibility = "visible";
				setIBoxContent(strHTML);
			}
				
		}
		
		loadCancelled = false;
		imgPreloader.src = url;
		

		
	} else if(url.indexOf("#") > 0) {
			var strHTML = "";
			ibox_type = 1;

			if(params['height']) {ibox.style.height = params['height']+'px';} 
			else {ibox.style.height = '280px';}
			
			if(params['width']) {ibox.style.width = params['width']+'px';} 
			else {ibox.style.width = '450px';}

		
			ibox.style.display = "";
			ibox.style.visibility = "hidden";
			posToCenter(ibox); 	
			ibox.style.visibility = "visible";

			var elemSrcId = url.substr(url.indexOf("#") + 1,1000);
			var elemSrc = getElem(elemSrcId);
			
			if(elemSrc) {
				strHTML = elemSrc.innerHTML;
			}

			setIBoxContent(strHTML);

	}else if(urlType=='.htm'||urlType=='.html'||urlType=='.php'||
			 urlType=='.asp'||urlType=='.aspx'||urlType=='.jsp'||
			 urlType=='.jst'||urlType=='.rb'||urlType=='.txt'||
			 urlType=='.cfm') {
			
	
			ibox_type = 2;
	
			showIndicator();
			http.open('get',url,true);
	
			http.onreadystatechange = function() {
				if(http.readyState == 4){
					hideIndicator();
					
					if(params['height']) {ibox.style.height = params['height']+'px';} 
					else {ibox.style.height = '280px';}
					
					if(params['width']) {ibox.style.width = params['width']+'px';} 
					else {ibox.style.width = '450px';}
		
					ibox.style.display = "";
					ibox.style.visibility = "hidden";
					posToCenter(ibox); 	
					ibox.style.visibility = "visible";

					var response = http.responseText;
					setIBoxContent(response);
					
					
				}
			}
			
			http.setRequestHeader("Content-Type","application/x-www-form-urlencoded; charset=UTF-8");
			http.send(null);

			
	} 
	
	ibox.style.opacity = 0;
	ibox.style.filter = 'alpha(opacity=0)';	
	var ibox_op_level = 10;
	
	setIboxOpacity = setOpacity;
	for (var i=0;i<=ibox_op_level;i++) {setTimeout("setIboxOpacity('ibox_wrapper',"+i+")",30*i);}


	if(ibox_type == 1 || ibox_type == 2) {
		ibox.onclick = null;getElem("ibox_close_a").onclick = function() {hideIbox();}
	} else {
		ibox.onclick = hideIbox;getElem("ibox_close_a").onclick = null;
	}

}




setOpacity = function (elemid,value)	{
		var e = getElem(elemid);
		e.style.opacity = value/10;
		e.style.filter = 'alpha(opacity=' + value*10 + ')';
}

resizeImageToScreen = function(objImg) {
	
	
	var pagesize = new getPageSize();
	
	var x = pagesize.width - 100;
	var y = pagesize.height - 100;

	if(objImg.width > x) { 
		objImg.height = objImg.height * (x/objImg.width); 
		objImg.width = x; 
		if(objImg.height > y) { 
			objImg.width = objImg.width * (y/objImg.height); 
			objImg.height = y; 
		}
	} 

	else if(objImg.height > y) { 
		objImg.width = objImg.width * (y/objImg.height); 
		objImg.height = y; 
		if(objImg.width > x) { 
			objImg.height = objImg.height * (x/objImg.width); 
			objImg.width = x;
		}
	}
	
	return objImg;
}

maintPos = function() {
	var ibox = getElem('ibox_wrapper');
	var box_w = getElem('ibox_w');
	var pagesize = new getPageSize();
	var ua = navigator.userAgent;
	
	if(ua.indexOf("MSIE ") != -1) {box_w.style.width = pagesize.width+'px';} 
	else {box_w.style.width = pagesize.width-20+'px';}

	if(ua.indexOf("Opera/9") != -1) {box_w.style.height = document.body.scrollHeight+'px';}
	else {box_w.style.height = document.body.scrollHeight+50+'px';}
	posToCenter(ibox);
	
}

hideIbox = function() {
	hideBG();
	var ibox = getElem('ibox_wrapper');
	ibox.style.display = "none";

	clearIboxContent();
	window.onscroll = null;
}

posToCenter = function(elem) {
	var scrollPos = new getScrollPos();
	var pageSize = new getPageSize();
	var emSize = new getElementSize(elem);
	var x = Math.round(pageSize.width/2) - (emSize.width /2) + scrollPos.scrollX;
	var y = Math.round(pageSize.height/2) - (emSize.height /2) + scrollPos.scrollY;	
	elem.style.left = x+'px';
	elem.style.top = y+'px';	
}

getScrollPos = function() {
	var docElem = document.documentElement;
	this.scrollX = self.pageXOffset || (docElem&&docElem.scrollLeft) || document.body.scrollLeft;
	this.scrollY = self.pageYOffset || (docElem&&docElem.scrollTop) || document.body.scrollTop;
}

getPageSize = function() {
	var docElem = document.documentElement
	this.width = self.innerWidth || (docElem&&docElem.clientWidth) || document.body.clientWidth;
	this.height = self.innerHeight || (docElem&&docElem.clientHeight) || document.body.clientHeight;
}

getElementSize = function(elem) {
	this.width = elem.offsetWidth ||  elem.style.pixelWidth;
	this.height = elem.offsetHeight || elem.style.pixelHeight;
}

setIBoxContent = function(str) {
	clearIboxContent();
	var e = getElem('ibox_content');
	e.innerHTML = str;
	e.style.overflow = "auto";
}
clearIboxContent = function() {
	var e = getElem('ibox_content');
	e.innerHTML = "";
	e.style.overflow = "hidden";
}


getElem = function(elemId) {
	return document.getElementById(elemId);	
}

// parseQuery code borrowed from thickbox, Thanks Cody!
parseQuery = function(query) {
   var Params = new Object ();
   if (!query) return Params; 
   var Pairs = query.split(/[;&]/);
   for ( var i = 0; i < Pairs.length; i++ ) {
      var KeyVal = Pairs[i].split('=');
      if ( ! KeyVal || KeyVal.length != 2 ) continue;
      var key = unescape( KeyVal[0] );
      var val = unescape( KeyVal[1] );
      val = val.replace(/\+/g, ' ');
      Params[key] = val;

   }
   
   return Params;
}

/********************************************************
 Make this IE7 Compatible ;)
 http://ajaxian.com/archives/ajax-on-ie-7-check-native-first
*********************************************************/
createRequestObject = function() {
	var xmlhttp;
		/*@cc_on
	@if (@_jscript_version>= 5)
			try {xmlhttp = new ActiveXObject("Msxml2.XMLHTTP");
			} catch (e) {
					try {xmlhttp = new ActiveXObject("Microsoft.XMLHTTP");}
					catch (E) {xmlhttp = false;}
			}
	@else
		xmlhttp = false;
	@end @*/
	if (!xmlhttp && typeof XMLHttpRequest != "undefined") {
			try {xmlhttp = new XMLHttpRequest();} catch (e) {xmlhttp = false;}
	}
	return xmlhttp;
}

var http = createRequestObject();

function addEvent(obj, evType, fn){ 
 if (obj.addEventListener){ 
   obj.addEventListener(evType, fn, false); 
   return true; 
 } else if (obj.attachEvent){ 
   var r = obj.attachEvent("on"+evType, fn); 
   return r; 
 } else { 
   return false; 
 } 
}
addEvent(window, 'load', init_ibox);