var serial = 'tr0';

function mouseOver(thisField) {
    thisField.style.cursor = 'hand';
    thisField.style.backgroundColor = '#efefef'; 
}

function mouseOut(thisField) {
    thisField.style.backgroundColor = '#ffffff';
}

function colorchange(thisField) {
    //var color = thisField.style.backgroundColor;
    thisField.style.cursor = 'hand';
    if (thisField.style.backgroundColor == '#efefef') {//FF進不來
        thisField.style.backgroundColor = '#ffffff';
    }
    else {
        thisField.style.backgroundColor = '#efefef';
    }
}

function fill(thisField, NAMES){ 

  document.getElementById(serial).style.backgroundColor = '#efefef';
  thisField.style.backgroundColor='#00FFFF';
  serial = thisField.id;

  var vv='\u32A3';
  var str;
  var strArray=new Array();
  strArray=NAMES.split(vv);
  for (x=0;x<strArray.length;x++){
    str=strArray[x];
    document.form1.elements[str].value='';

    if(thisField.childNodes[x].childNodes[0].nodeValue != "�@"){
      document.form1.elements[str].value=thisField.childNodes[x].childNodes[0].nodeValue;
    }
    else
      document.form1.elements[str].value='';
  }
}

function fill_parent(thisField, NAMES){  

  document.getElementById(serial).style.backgroundColor = '#efefef';
  thisField.style.backgroundColor='#00FFFF';
  serial = thisField.id;

  var vv='\u32A3';
  var str;
  var strArray=new Array();
  strArray=NAMES.split(vv);
  for (x=0;x<strArray.length;x++){
    str=strArray[x];
    str=strArray[x];parent.document.form1.elements[str].value='';

    if(thisField.childNodes[x].childNodes[0].nodeValue != "�@"){
      parent.document.form1.elements[str].value=thisField.childNodes[x].childNodes[0].nodeValue;
    }
    else
      parent.document.form1.elements[str].value='';
  }
}

function fill_iframe(thisField, NAMES){  

  document.getElementById(serial).style.backgroundColor = '#efefef';
  thisField.style.backgroundColor='#00FFFF';
  serial = thisField.id;

  var vv='\u32A3';
  var str;
  var strArray=new Array();
  strArray=NAMES.split(vv);
  for (x=0;x<strArray.length;x++){
    str=strArray[x];
    parent.document.FrameInput.form1.elements[str].value='';

    if(thisField.childNodes[x].childNodes[0].nodeValue != "�@"){
      parent.document.FrameInput.form1.elements[str].value=thisField.childNodes[x].childNodes[0].nodeValue;
    }
    else
      parent.document.FrameInput.form1.elements[str].value='';
  }
}

function getfill(id){
  document.getElementById(id).style.backgroundColor = '#00FFFF';
  serial = id;
}
