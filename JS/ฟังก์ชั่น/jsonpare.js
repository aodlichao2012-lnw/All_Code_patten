// เอา json มาแปลงใส่ Label

function call_set_label1() {
    PageMethods.set_label(set_label1);
}

function set_label1(response, userContext, methodName) {
    //alert('in chart 1');
    var json_obj = JSON.parse(response);
    //document.getElementById("res").innerHTML = JSON.stringify(json_obj, 4, null);
    //alert (json_obj[0].pm) ;
    document.getElementById("pm").innerHTML = json_obj[0].pm;
    document.getElementById("cctv").innerHTML = json_obj[0].cctv;
    document.getElementById("live_trafic").innerHTML = json_obj[0].trafic;
    document.getElementById("licensep").innerHTML = json_obj[0].license;
    document.getElementById("light_b").innerHTML = json_obj[0].lightb;
    document.getElementById("water_mng").innerHTML = json_obj[0].water;
    document.getElementById("water_tread").innerHTML = json_obj[0].qc;
}