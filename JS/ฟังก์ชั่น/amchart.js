// chang color

pieSeries.slices.template.propertyFields.fill = "color";
pieSeries.slices.template.propertyFields.fill = am4core.color("#0000FF");


series.colors.list = [
    am4core.color("#845EC2"),
    am4core.color("#D65DB1"),
    am4core.color("#FF6F91"),
    am4core.color("#FF9671"),
    am4core.color("#FFC75F"),
    am4core.color("#F9F871"),
];


// stack

series1.stacked = true;


// กราฟต่างๆ
// 1 pie 

function add_chart1 (response, userContext, methodName) {
    //alert('in chart 1');
    am4core.ready(function () {
    //am4core.useTheme(am4themes_kelly);
        am4core.useTheme(am4themes_frozen);

    var chart = am4core.create("chart1", am4charts.PieChart);
    chart.hiddenState.properties.opacity = 0; // this creates initial fade-in
    chart.legend = new am4charts.Legend();

    //document.getElementById("res").innerHTML = JSON.stringify(response, 4, null);
        chart.data = JSON.parse(response)
    //alert('in chart 1.2');
    //chart.data = [{
        //    "display": "Found",
    //    "val": 300
    //},
    //{
        //    "display": "Finish",
    //    "val": 210
    //}]
    var series = chart.series.push(new am4charts.PieSeries());
    series.dataFields.value = "val";
    series.dataFields.category = "display";
    /* pieSeries.slices.template.propertyFields.fill = am4core.color("#0000FF");*/
    /*series.slices.template.propertyFields.fill = am4core.color("#FF9933");*/
        //series.fill = am4core.color("#0000FF");
        //series.slices.template.stroke = am4core.color("#fff");
        chart.cursor = new am4charts.XYCursor();

        series.colors.list = [
            am4core.color("#FF4500"),
            am4core.color("#FF8C00"),
           
        ];


  });  
}

// 2 XY Chart
function add_chart2(response, userContext, methodName) {
            
            //alert('in chart 2');
            am4core.useTheme(am4themes_material);
            am4core.useTheme(am4themes_animated);
            // Themes end

            // Create chart instance
            var chart = am4core.create("chart2", am4charts.XYChart);
            //document.getElementById("res").innerHTML = JSON.stringify(response, 4, null);
            // Add data
            //chart.data = [{
            //    "st_name": "station1",
            //    "pm": 10,
            //    "traf": 5
            //}, {
            //    "st_name": "station2",
            //    "pm": 20,
            //    "traf": 12
            //}, {
            //    "st_name": "station3",
            //    "pm": 23,
            //    "traf": 30
            //}];
            chart.data = JSON.parse(response)
            alert(response);
            chart.legend = new am4charts.Legend();
            chart.legend.position = "right";

            // Create axes
            var categoryAxis = chart.yAxes.push(new am4charts.CategoryAxis());
            categoryAxis.dataFields.category = "station";
            categoryAxis.renderer.grid.template.opacity = 0;

            var valueAxis = chart.xAxes.push(new am4charts.ValueAxis());
            valueAxis.min = 0;
            valueAxis.renderer.grid.template.opacity = 0;
            valueAxis.renderer.ticks.template.strokeOpacity = 0.5;
            valueAxis.renderer.ticks.template.stroke = am4core.color("#495C43");
            valueAxis.renderer.ticks.template.length = 10;
            valueAxis.renderer.line.strokeOpacity = 0.5;
            valueAxis.renderer.baseGrid.disabled = true;
            valueAxis.renderer.minGridDistance = 40;

            // Create series
            function createSeries(field, name) {
                var series = chart.series.push(new am4charts.ColumnSeries());
                series.dataFields.valueX = field;
                series.dataFields.categoryY = "station";
                series.stacked = true;
                series.name = name;

                var labelBullet = series.bullets.push(new am4charts.LabelBullet());
                labelBullet.locationX = 0.5;
                labelBullet.label.text = "{valueX}";
                labelBullet.label.fill = am4core.color("#fff");
            }

            createSeries("pm", "ค่า PM 2.5");
            createSeries("traf", "สภาพจราจร");
}

// 3 XY chart 2

function add_chart3(response, userContext, methodName) {
    //alert ('in chart 3') ;
    //document.getElementById("res").innerHTML = JSON.stringify(response, 4, null);
    //alert('in chart 2');
    am4core.useTheme(am4themes_material);
    am4core.useTheme(am4themes_animated);
    // Themes end

    // Create chart instance
    var chart = am4core.create("chartdiv", am4charts.XYChart);

    // Add data
    chart.data = JSON.parse(response);

    // Create axes
    var categoryAxis = chart.xAxes.push(new am4charts.CategoryAxis());
    categoryAxis.dataFields.category = "mm";
  /*  categoryAxis.title.text = "Local country offices";*/
    categoryAxis.renderer.grid.template.location = 0;
    categoryAxis.renderer.minGridDistance = 20;

    var valueAxis = chart.yAxes.push(new am4charts.ValueAxis());
    valueAxis.title.text = "Expenditure (M)";

    // Create series
    var series = chart.series.push(new am4charts.ColumnSeries());
    series.sequencedInterpolation = true;
    series.columns.template.width = am4core.percent(100);
    series.dataFields.valueY = "blub";
    series.dataFields.categoryX = "mm";
    series.tooltipText = "[{categoryX}: bold]{valueY}[/]";
    series.columns.template.strokeWidth = 0;
    series.paddingRight = am4core.percent(10);
    series.fill = am4core.color("#0000FF");

    series.tooltip.pointerOrientation = "vertical";

    series.columns.template.column.cornerRadiusTopLeft = 1;
    series.columns.template.column.cornerRadiusTopRight = 1;
    series.columns.template.column.fillOpacity = 0.8;
    series.name = "เทส";
    // This has no effect
    // series.stacked = true;

    var series2 = chart.series.push(new am4charts.ColumnSeries());
    series2.sequencedInterpolation = true;
    series2.columns.template.width = am4core.percent(100);
    series2.dataFields.valueY = "acc";
    series2.dataFields.categoryX = "mm";
    series2.tooltipText = "[{categoryX}: bold]{valueY}[/]";
    series2.columns.template.strokeWidth = 0;
    series2.fill = am4core.color("#FF0001");
    series2.name = "เทส";


    series2.tooltip.pointerOrientation = "vertical";


    series2.columns.template.column.cornerRadiusTopLeft = 1;
    series2.columns.template.column.cornerRadiusTopRight = 1;
    series2.columns.template.column.fillOpacity = 0.8;
    // Do not try to stack on top of previous series
    // series2.stacked = true;


    // Add cursor
    chart.cursor = new am4charts.XYCursor();

    // Add legend
    chart.legend = new am4charts.Legend();
}

//เช็ต label
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