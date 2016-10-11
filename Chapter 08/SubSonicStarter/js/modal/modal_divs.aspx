	    <!--here for the modal windows-->
  <div id="popupMask">&nbsp;</div>
  <div id="popupContainer">
	    <div id="popupInner">
		    <div id="popupTitleBar">
			    <div id="popupTitle"></div>
			    <div id="popupControls">
				    <img src="<%=Page.ResolveUrl("~/images/close.gif")%>" onclick="hidePopWin(false);document.location.reload()" />
			    </div>
		    </div>
		    <iframe src="<%=Page.ResolveUrl("~/loading.htm")%>" style="width:100%;background-color:transparent;" scrolling="auto" frameborder="0" id="popupFrame" name="popupFrame" ></iframe>
	    </div>
    </div>