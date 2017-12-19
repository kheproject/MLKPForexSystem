function preventBack() {window.history.forward();}
       setTimeout("preventBack()", 10);
       window.onunload=function(){null};
