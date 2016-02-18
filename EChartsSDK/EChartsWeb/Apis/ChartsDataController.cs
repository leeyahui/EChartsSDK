﻿using ECharts;
using ECharts.Entities;
using ECharts.Entities.axis;
using ECharts.Entities.feature;
using ECharts.Entities.series;
using ECharts.Entities.series.data;
using ECharts.Entities.style;
using EChartsWeb.Util;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EChartsWeb.Apis
{
    public class ChartsDataController : ApiController
    {
        #region tooltip
        //[AcceptVerbs("GET", "POST")]
        //public string ToolTip()
        //{
        //    Dictionary<string, double> datas1 = new Dictionary<string, double>();

        //    datas1.Add("周一", 332);
        //    datas1.Add("周二", 301);
        //    datas1.Add("周三", 334);
        //    datas1.Add("周四", 390);
        //    datas1.Add("周五", 330);
        //    datas1.Add("周六", 330);
        //    datas1.Add("周日", 320);

        //    Dictionary<string, double> datas2 = new Dictionary<string, double>();
        //    datas2.Add("周一", 862);
        //    datas2.Add("周二", 1018);
        //    datas2.Add("周三", 964);
        //    datas2.Add("周四", 1026);
        //    datas2.Add("周五", 1679);
        //    datas2.Add("周六", 1600);
        //    datas2.Add("周日", 157);

        //    ChartOption option = new ChartOption();
        //    option.tooltip = new ToolTip()
        //    {
        //        trigger = TriggerType.axis,
        //        show = true,
        //        showContent = true,
        //        showDelay = 0,
        //        hideDelay = 50,
        //        transitionDuration = 0,
        //        borderRadius = 8,
        //        borderWidth = 2,
        //        padding = 10,
        //        position = new JRaw(string.Format(@"function(p){{
        //            return [p[0] + 10,p[1]-10];
        //        }}")),
        //        textStyle = new TextStyle
        //        {
        //            color = "yellow",
        //            decoration = "none",
        //            fontFamily = "Verdana,sans-serif",
        //            fontSize = 15,
        //            fontStyle = FontStyleType.italic,
        //            fontWeight = "bold"
        //        },
        //        formatter = new JRaw(string.Format(@"function(params){{  
        //        var res = 'function formatter:<br/>'+params[0].name;
        //        for(var i=0,l=params.length;i<l;i++){{
        //            res +='<br/>'+params[i].seriesName+':'+params[i].value;
        //        }}
        //        return res;}}"))
        //    };

        //    option.xAxis = new List<Axis>()
        //    {
        //        new ValueAxis()
        //        {
        //             data = new List<object>(datas1.Keys.ToList()),
        //             type = AxisType.category
        //        }
        //    };
        //    option.yAxis = new List<Axis>() {
        //        new ValueAxis()
        //        {
        //             type = AxisType.value,
        //        }
        //    };

        //    option.series = new List<Object>() {
        //        new Bar() {
        //             name = "坐标触发",
        //             type = ChartType.bar,
        //             data=  datas1.Values.ToList()
        //        },
        //        new Bar() {
        //             name = "坐标触发",
        //             type = ChartType.bar,
        //             data= datas2.Values.ToList()
        //        },
        //        new Bar() {
        //            name = "数据项触发1",
        //            type = ChartType.bar,
        //            tooltip = new ToolTip() {
        //                 trigger = TriggerType.item,
        //                 position= new JRaw("[0,0]"),
        //                 formatter = new JRaw(@"Series formatter:<br/>{a}<br/>{b}:{c}").ToString()
        //            },
        //            stack ="数据项",
        //            data =  new List<object>(){
        //               120,
        //               132,
        //               new SeriesData(){
        //                    value = 301,
        //                    itemStyle  = new ItemStyle(){
        //                      normal = new Normal(){
        //                       color="red"
        //                      }
        //                    },
        //                    tooltip=new ToolTip(){
        //                         backgroundColor="blue",
        //                     formatter=new JRaw(@"Data formatter: <br/>{a}<br/>{b}:{c}").ToString(),
        //                    }
        //               },
        //               134,
        //               90,
        //               new SeriesData(){
        //                value = 230,
        //                tooltip = new ToolTip(){
        //                 show=false,
        //                }
        //               }
        //            }
        //        },
        //        new Bar(){
        //            name="数据项触发2",
        //            type = ChartType.bar,
        //            tooltip = new ToolTip(){
        //                 show = false,
        //                 trigger=TriggerType.item,
        //            },
        //            stack="数据项",
        //            data = datas1.Values.ToList()
        //        }
        //    };

        //    var result = JsonTools.ObjectToJson2(option);
        //    return result;
        //}
        #endregion
        
        #region line data
        [AcceptVerbs("GET", "POST")]
        public string Line()
        {
            IList<string> ads = ChartsUtil.Ads();
            IList<string> weeks = ChartsUtil.Weeks();
            ChartOption option = new ChartOption();
            option.ToolTip().Trigger(TriggerType.axis);
            option.Legend().SetData(new List<object>(ads));

            
            var feature = new Feature();
            feature.DataView().Show(true).ReadOnly(false);
            feature.Mark().Show(true);
            feature.Restore().Show(true);
            feature.MagicType().Show(true).Type("line", "bar", "stack", "tiled");
            feature.SaveAsImage().Show(true);
            option.ToolBox().Show(true).SetFeature(feature);               


            option.calculable = true;
            var x = new CategoryAxis();
            x.BoundaryGap(false).SetData(new List<object>(weeks));
            option.XAxis(x);
            option.YAxis(new ValueAxis());
            
            
            var l1 = new Line("邮件营销");
            var s = new ItemStyle();
            s.Normal().AreaStyle().Color(new JRaw(@"(function () {
                require(['zrender'],
                function (zrender) {
                    zr = zrender.init(document.getElementById('charts'));
                    color = require('zrender/tool/color');
                    return color.getLinearGradient(
                      0, 200, 0, 400,
                      [[0, 'rgba(255,0,0,0.8)'], [0.8, 'rgba(255,255,255,0.1)']]);
                });
            })()"));
            l1.Stack("总量").Symbol(SymbolType.none).SetItemStyle(s);
            var sd = new SeriesData<int>(90);
            sd.Symbol(SymbolType.droplet).SymbolSize(5);
            l1.Data(120, 132, 301, 134, sd, 230, 210);

            var l2 = new Line("联盟广告");
            var sd2 = new SeriesData<int>(201);
            sd2.Symbol(SymbolType.star).SymbolSize(15)
                .ItemStyle().Normal().Label().Show(true)
                .TextStyle().FontSize(20).FontFamily("微软雅黑").FontWeight("bold");
            l2.Stack("总量").Smooth(true).Symbol(@"http://echarts.baidu.com/doc/asset/ico/favicon.png").SymbolSize(8)
                .Data(120, 82, sd2, 190, new SeriesData<int>(134).Symbol(SymbolType.none),
                new SeriesData<int>(134).Symbol(SymbolType.none), 190,
                new SeriesData<int>(230).Symbol(SymbolType.emptypin).SymbolSize(8), 190, 110);

            var l3 = new Line("直接访问");
            var s1 = new ItemStyle();
            s1.Normal().Color("red").LineStyle().Width(2).Type(LineStyleType.dashed);
            s1.Emphasis().Color("blue");
            l3.Stack("总量").Symbol(SymbolType.arrow).SymbolSize(6).SymbolRotate(-45)
                .SetItemStyle(s1);

            var s2 = new ItemStyle();
            s2.Normal().Color("yelowgreen");
            s2.Emphasis().Color("orange");
            var sd3 = new SeriesData<int>(390);
            sd3.Symbol("star6").SymbolSize(20).SymbolRotate(10)
                .Label().Show(true).Position(StyleLabelTyle.inside)
                .TextStyle().FontSize(20);

            l3.SetItemStyle(s2);
            l3.Data(320, 332, "-", 334, sd3, 330, 320);

            var l4 = new Line("搜索引擎");
            var s3 = new ItemStyle();
            s3.Normal().LineStyle().Width(2).Color(new JRaw(@"(function (){
                            require(['zrender'],
                           function (zrender) {
                              zr = zrender.init(document.getElementById('charts'));
                              color = require('zrender/tool/color');                            
                              return color.getLinearGradient(
                               0, 0, 1000, 0,
                               [[0, 'rgba(255,0,0,0.8)'],[0.8, 'rgba(255,255,0,0.8)']]);
                            });                            
                        })()")).ShadowColor("rgba(0,0,0,0.5)")
                        .ShadowBlur(10).ShadowOffsetX(8).ShadowOffsetY(8);
            s3.Emphasis().Label().Show(true);
            l4.SetItemStyle(s3);
            var sd4 = new SeriesData<int>(734);
            sd4.Symbol(SymbolType.emptyheart).SymbolSize(10);
            l4.Data(620, 732, 791, sd4, 890, 930, 820);

            Line l5 = new Line("视频广告");
            l5.stack = "总量";
            l5.data = ChartsUtil.Datas(7, 820, 1400); ;

            option.Series<Line>(l1, l2, l3, l4, l5);
            var result = JsonTools.ObjectToJson2(option);
            return result;
        }

        [AcceptVerbs("GET", "POST")]
        [ActionName("line1")]
        public string StdLine()
        {
            IList<string> weeks = ChartsUtil.Weeks();

            IList<int> datas1 = ChartsUtil.Datas(7, 10, 15);

            IList<int> datas2 = ChartsUtil.Datas(7, -2, 5);

            int min = datas2.Min();
            int index = datas2.IndexOf(min);

            ChartOption option = new ChartOption();

            option.title = new Title()
            {
                show = true,
                text = "未来一周天气变化",
                subtext = "纯虚构数据"
            };


            option.tooltip = new ToolTip()
            {
                trigger = TriggerType.axis
            };

            option.legend = new Legend()
            {
                data = new List<object>(){
                   "最高温度",
                   "最低温度"
                 }
            };

            option.calculable = true;

            option.xAxis = new List<Axis>()
            {
                new CategoryAxis()
                {                    
                    type = AxisType.category,                    
                    boundaryGap= false,
                    data = new List<object>(weeks)
                }
            };

            option.yAxis = new List<Axis>()
            {
                new ValueAxis()
                {
                    type = AxisType.value,
                    axisLabel = new AxisLabel(){
                     formatter=new JRaw("{value} ℃").ToString()
                    }
                }
            };
            option.series = new List<object>()
            {
                    new Line()
                    {
                        name = "最高温度",
                        type =  ChartType.line,
                        data =  datas1,
                        markPoint =  new MarkPoint()
                        {
                                data = new List<object>()
                                {
                                    new MarkData()
                                    {
                                         name = "最大值",
                                         type= MarkType.max,                                                                                                                           
                                    },
                                    new MarkData()
                                    {
                                         name = "最小值",
                                         type= MarkType.min,
                                    }
                                }
                        },
                        markLine = new MarkLine()
                        {
                                data = new List<object>()
                                {
                                     new MarkData()
                                     {
                                          name = "平均值",
                                          type = MarkType.average
                                     }
                                }
                       }
              },
              new Line(){
                name="最低温度",
                type = ChartType.line,
                data = datas2,
                markPoint= new MarkPoint(){
                 data = new List<object>(){
                    new MarkData(){
                     name="周最低",
                     value = min,
                     xAxis = index,
                     yAxis = min+0.5,
                    }        
                 }
                },
               markLine = new MarkLine(){
                data = new List<object>(){
                   new MarkData(){
                    type = MarkType.average,
                    name = "平均值"
                   }
                }
               }
              }
            };
            var result = JsonTools.ObjectToJson2(option);
            return result;
        }

        [AcceptVerbs("GET", "POST")]
        [ActionName("line2")]
        public string HeapLine()
        {
            IList<string> ads = ChartsUtil.Ads();
            IList<string> weeks = ChartsUtil.Weeks();
            IList<int> data1 = ChartsUtil.Datas(7, 90, 240);
            IList<int> data2 = ChartsUtil.Datas(7, 190, 310);
            IList<int> data3 = ChartsUtil.Datas(7, 150, 410);
            IList<int> data4 = ChartsUtil.Datas(7, 300, 400);
            IList<int> data5 = ChartsUtil.Datas(7, 820, 1400);

            ChartOption option = new ChartOption();
            option.legend = new Legend()
            {
                data = new List<object>(ads)
            };

            option.tooltip = new ECharts.Entities.ToolTip()
            {
                trigger = TriggerType.axis
            };

            option.calculable = true;

            option.XAxis(new CategoryAxis()
            {
                type = AxisType.category,
                boundaryGap = false,
                data = new List<object>(weeks),
            });

            option.YAxis(new ValueAxis()
            {
                type = AxisType.value
            });

            Line l1 = new Line(ads[0]);
            l1.stack = "总量";
            l1.data = data1;

            Line l2 = new Line(ads[1]);
            l2.stack = "总量";
            l2.data = data2;

            Line l3 = new Line(ads[2]);
            l3.stack = "总量";
            l3.data = data3;

            Line l4 = new Line(ads[3]);
            l4.stack = "总量";
            l4.data = data4;

            Line l5 = new Line(ads[4]);
            l5.stack = "总量";
            l5.data = data5;

            option.Series<Line>(l1, l2, l3, l4, l5);


            var result = JsonTools.ObjectToJson2(option);
            return result;
        }


        [AcceptVerbs("GET", "POST")]
        [ActionName("line3")]
        public string StdArea()
        {
            IList<string> weeks = ChartsUtil.Weeks();

            IList<int> datas1 = ChartsUtil.Datas(7, 10, 800);
            IList<int> datas2 = ChartsUtil.Datas(7, 10, 600);
            IList<int> datas3 = ChartsUtil.Datas(7, 20, 1300);

            ChartOption option = new ChartOption();

            option.title = new Title()
            {
                text = "某楼盘销售情况",
                subtext = "纯属虚构"
            };

            option.tooltip = new ToolTip()
            {
                trigger = TriggerType.axis
            };

            option.Legend("意向", "预购", "成交");

            option.calculable = true;

            option.XAxis(new CategoryAxis()
            {
                type = AxisType.category,
                boundaryGap = false,
                data = new List<object>(weeks),
            });

            option.YAxis(new ValueAxis()
            {
                type = AxisType.value,
            });
            ItemStyle itemStyle = new ItemStyle()
            {
                normal = new Normal()
                {
                    areaStyle = new AreaStyle()
                    {
                        type = AreaStyleType.Default,
                    }
                }
            };
            Line l1 = new Line("预购");
            l1.smooth = true;
            l1.itemStyle = itemStyle;
            l1.data = datas1;

            Line l2 = new Line("成交");
            l2.smooth = true;
            l2.itemStyle = itemStyle;
            l2.data = datas2;

            Line l3 = new Line("意向");
            l3.smooth = true;
            l3.itemStyle = itemStyle;
            l3.data = datas3;

            option.Series<Line>(l1, l2, l3);

            var result = JsonTools.ObjectToJson2(option);
            return result;
        }

        [AcceptVerbs("GET", "POST")]
        [ActionName("line4")]
        public string HeapArea()
        {
            IList<string> ads = ChartsUtil.Ads();
            IList<string> weeks = ChartsUtil.Weeks();
            IList<int> data1 = ChartsUtil.Datas(7, 90, 240);
            IList<int> data2 = ChartsUtil.Datas(7, 190, 310);
            IList<int> data3 = ChartsUtil.Datas(7, 150, 410);
            IList<int> data4 = ChartsUtil.Datas(7, 300, 400);
            IList<int> data5 = ChartsUtil.Datas(7, 820, 1400);

            ChartOption option = new ChartOption();
            Legend legend = new Legend();
            legend.data = new List<object>(ads);
            option.Legend(legend);

            option.tooltip = new ECharts.Entities.ToolTip()
            {
                trigger = TriggerType.axis
            };

            option.calculable = true;

            option.XAxis(new CategoryAxis()
            {
                type = AxisType.category,
                boundaryGap = false,
                data = new List<object>(weeks),
            });

            option.YAxis(new ValueAxis()
            {
                type = AxisType.value
            });

            ItemStyle itemStyle = new ItemStyle();
            itemStyle.Normal().AreaStyle().SetType(AreaStyleType.Default);
           

            Line l1 = new Line(ads[0]);
            l1.stack = "总量";
            l1.data = data1;
            l1.itemStyle = itemStyle;

            Line l2 = new Line(ads[1]);
            l2.stack = "总量";
            l2.data = data2;
            l2.itemStyle = itemStyle;

            Line l3 = new Line(ads[2]);
            l3.stack = "总量";
            l3.data = data3;
            l3.itemStyle = itemStyle;

            Line l4 = new Line(ads[3]);
            l4.stack = "总量";
            l4.data = data4;
            l4.itemStyle = itemStyle;

            Line l5 = new Line(ads[4]);
            l5.stack = "总量";
            l5.data = data5;
            l5.itemStyle = itemStyle;

            option.Series<Line>(l1, l2, l3, l4, l5);


            var result = JsonTools.ObjectToJson2(option);
            return result; 
        }

        [AcceptVerbs("GET", "POST")]
        [ActionName("line5")]
        public string StdLine2()
        {
            IList<int> temp = ChartsUtil.Steps(6, -80, 20);
            IList<int> height = ChartsUtil.Datas(6, 0, 80);
           

            ChartOption option = new ChartOption();
            option.Legend("高度与气温变化关系");
            option.calculable = true;
            option.ToolTip().Trigger(TriggerType.axis)
                .Formatter(new JRaw("Temperature : <br/>{b}km : {c}°C").ToString());
            var x = new ValueAxis();
            x.AxisLabel().Formatter(new JRaw("{value} °C").ToString());
            option.XAxis(x);
            var y = new CategoryAxis();
            y.BoundaryGap(false);
            y.AxisLine().OnZero(false);
            y.AxisLabel().Formatter(new JRaw("{value} km").ToString());
            y.SetData(temp.Cast<object>().ToList());
            option.YAxis(y);
            var line = new Line("高度与气温变化关系");
            var itemStyle = new ItemStyle();
            itemStyle.Normal().LineStyle().ShadowColor("rgba(0,0,0,0,4)");
            line.Smooth(true);
            line.itemStyle = itemStyle;
            line.data = height;
            option.Series<Line>(line);
            var result = JsonTools.ObjectToJson2(option);
            return result;

        }

        [AcceptVerbs("GET", "POST")]
        [ActionName("line6")]
        public string Area()
        {

            var times = ChartsUtil.TimeSteps(new DateTime(2009, 6, 12, 2, 0, 0), new DateTime(2009, 10, 18, 8, 0, 0), new TimeSpan(1, 0, 0));
         
            var flows = ChartsUtil.Flows();
            var rains = ChartsUtil.Rains();

            ChartOption option = new ChartOption();
            option.Title().Text("雨量流量关系图").SubText("数据来自西安兰特水电测控技术有限公司")
                .X(HorizontalType.center);

            option.ToolTip().Trigger(TriggerType.axis)
                .Formatter(new JRaw(@"function(params) {
                    return params[0].name + '<br/>'
                   + params[0].seriesName + ' : ' + params[0].value + ' (m^3/s)<br/>'
                   + params[1].seriesName + ' : ' + -params[1].value + ' (mm)';}"));
            option.Legend("流量", "降雨量").Legend().X(HorizontalType.left);

            option.DataZoom().Show(true).Realtime(true).Start(0).End(100);

            var x = new CategoryAxis();
            x.BoundaryGap(false).AxisLine().OnZero(false);
            x.SetData(times.Cast<object>().ToList());
            option.XAxis(x);

            var y1 = new ValueAxis();
            y1.Name("流量").Max(500);
            var y2 = new ValueAxis();
            y2.Name("降雨量").AxisLabel().Formatter(new JRaw("function(v){return -v;}"));
            option.YAxis(y1, y2);

            var itemStyle = new ItemStyle();
            itemStyle.Normal().AreaStyle().SetType(AreaStyleType.Default);
            var l1 = new Line("流量");
            l1.itemStyle = itemStyle;
            l1.data = flows;            

            var l2 = new Line("降雨量");
            l2.YAxisIndex(1);
            l2.itemStyle = itemStyle;
            l2.data = new JRaw(string.Format(@"(function(){{
                var oriData = [{0}]; 
                var len = oriData.length;
                while(len--) {{
                    oriData[len] *= -1;
                }}
                return oriData;}})()", string.Join(",", rains)));

            option.Series<Line>(l1, l2);

            var result = JsonTools.ObjectToJson2(option);
            return result;
        }

        [AcceptVerbs("GET", "POST")]
        [ActionName("line7")]
        public string UnequalLine()
        {
            ChartOption option = new ChartOption();

            option.Title().Text("双数值轴折线").SubText("纯属虚构");
            option.ToolTip().Trigger(TriggerType.axis).Formatter(new JRaw(@"function (params) {
            return params.seriesName + ' : [ '
                   + params.value[0] + ', ' 
                   + params.value[1] + ' ]';
        }")).AxisPointer().Show(true).Type(AxisPointType.cross)
           .LineStyle().Type(LineStyleType.dashed).Width(1);
            option.Legend("数据1", "数据2");
            option.calculable = true;
            option.XAxis(new ValueAxis());
            var y = new ValueAxis();
            y.AxisLine().LineStyle().Color("#dc143c");
            option.YAxis(y);

            var l1 = new Line("数据1");
            l1.data = ChartsUtil.TowDatas(9, 2, 0, 20);
            var mp1 = new MarkData("最大值");
            mp1.Type(MarkType.max).Symbol("emptyCircle")
                .ItemStyle().Normal().Color("#dc143c").Label().Position(StyleLabelTyle.top);
            var mp2 = new MarkData("最小值");
            mp2.Type(MarkType.min).Symbol("emptyCircle")
                .ItemStyle().Normal().Color("#dc143c").Label().Position(StyleLabelTyle.bottom);
            var mp3 = new MarkData("最大值");
            mp3.Type(MarkType.max).Symbol("emptyCircle").ValueIndex(0)
                .ItemStyle().Normal().Color("#1e90ff").Label().Position(StyleLabelTyle.right);
            var mp4 = new MarkData("最小值");
            mp4.Type(MarkType.min).Symbol("emptyCircle").ValueIndex(0)
                .ItemStyle().Normal().Color("#1e90ff").Label().Position(StyleLabelTyle.left);
            l1.MarkPoint().Data(mp1,mp2,mp3,mp4);

            var ml1 = new MarkData("最大值");
            ml1.Type(MarkType.max)
                .ItemStyle().Normal().Color("#dc143c");
            var ml2 = new MarkData("最小值");
            ml2.Type(MarkType.min)
                .ItemStyle().Normal().Color("#dc143c");
            var ml3 = new MarkData("平均值");
            ml3.Type(MarkType.average)
                .ItemStyle().Normal().Color("#dc143c");
            var ml4 = new MarkData("最大值");
            ml4.Type(MarkType.max).ValueIndex(0)
                .ItemStyle().Normal().Color("#1e90ff");
            var ml5 = new MarkData("最小值");
            ml5.Type(MarkType.min).ValueIndex(0)
                .ItemStyle().Normal().Color("#1e90ff");
            var ml6 = new MarkData("平均值");
            ml6.Type(MarkType.average).ValueIndex(0)
              .ItemStyle().Normal().Color("#1e90ff");
            l1.MarkLine().Data(ml1, ml2, ml3, ml4, ml5, ml6);

            var l2 = new Line("数据2");
            l2.data = ChartsUtil.TowDatas(9, 2, 0, 20);
            option.Series<Line>(l1, l2);
            var result = JsonTools.ObjectToJson2(option);
            return result;
        }

        [AcceptVerbs("GET", "POST")]
        [ActionName("line8")]
        public string TimeLine()
        {
            ChartOption option = new ChartOption();
            option.Title().Text("时间坐标折线图").SubText("dataZoom支持");
            option.ToolTip().Trigger(TriggerType.item)
                .Formatter(new JRaw(@"function (params) {
                    var date = new Date(params.value[0]);
                    data = date.getFullYear() + '-'
                           + (date.getMonth() + 1) + '-'
                           + date.getDate() + ' '
                           + date.getHours() + ':'
                           + date.getMinutes();
                    return data + '<br/>'
                           + params.value[1] + ', ' 
                           + params.value[2];
                }"));
            option.DataZoom().Show(true).Start(70);
            option.Legend().Data("series1");
            option.Grid().Y2(80);
            option.XAxis(new TimeAxis().SplitNumber(10));
            option.YAxis(new ValueAxis());
            var line = new Line("series1");
            line.showAllSymbol = true;
            line.symbolSize = new JRaw(@"function (value){
                return Math.round(value[2]/10) + 2;
            }");
            line.data = new JRaw(@" (function () {
                var d = [];
                var len = 0;
                var now = new Date();
                var value;
                while (len++ < 200) {
                    d.push([
                        new Date(2014, 9, 1, 0, len * 10000),
                        (Math.random()*30).toFixed(2) - 0,
                        (Math.random()*100).toFixed(2) - 0
                    ]);
                }
                return d;
            })()");

            option.Series<Line>(line);

            var result = JsonTools.ObjectToJson2(option);
            return result;
        }

        [AcceptVerbs("GET", "POST")]
        [ActionName("line9")]
        public string LogLine()
        {

            ChartOption option = new ChartOption();
            option.Title().Text("对数轴示例").X(HorizontalType.center);
            option.ToolTip().Trigger(TriggerType.item).Formatter(new JRaw("{a} <br/>{b} : {c}").ToString());
            var legend = new Legend();
            legend.X(HorizontalType.left);
            legend.Data("2的指数", "3的指数");
            option.legend = legend;
            var x = new CategoryAxis();
            x.Name("x").SplitLine().Show(true);
            
            IList<string> baseDatas = ChartsUtil.Sequences(1, 9).ToList().ConvertAll(f=>f.ToString()).ToList();
            x.data= new List<object>(baseDatas);            
            option.XAxis(x);

            var y =new LogAxis();
            y.Name("y").LogLabelBase(3).SplitNumber(3);
            option.YAxis(y);

            var l1 = new Line("3的指数");
            l1.data = ChartsUtil.Exps(baseDatas.Count(), 3);
            var l2 = new Line("2的指数");
            l2.data = ChartsUtil.Exps(baseDatas.Count(), 2);
            option.Series<Line>(l1, l2);
            var result = JsonTools.ObjectToJson2(option);
            return result;
        }
        #endregion

        #region bar data

        [AcceptVerbs("GET", "POST")]
        [ActionName("bar1")]
        public string Column()
        {

            ChartOption option = new ChartOption();
            option.ToolTip().Trigger(TriggerType.axis)
               .AxisPointer().Type(AxisPointType.shadow);

            option.Legend("蒸发量", "降雨量");
            option.ToolBox(ToolBox());
            option.calculable = true;
            var x = new CategoryAxis();
            x.SetData(ChartsUtil.Months().Cast<object>().ToList());
            option.XAxis(x);
            var y = new ValueAxis();
            option.YAxis(y);
            var bar1 = new Bar("蒸发量");
            bar1.SetData(ChartsData.EvapsYear);
            bar1.MarkPoint().Data(new MarkData("最大值", MarkType.max), new MarkData("最小值", MarkType.min));
            bar1.MarkLine().Data(new MarkData("平均值", MarkType.average));

            var bar2 = new Bar("降水量");
            bar2.SetData(ChartsData.RainsYear);
            var mp1 = new MarkData("年最高");
            double rainMax = ChartsData.RainsYear.Max();
            mp1.value = rainMax;
            mp1.yAxis = rainMax + 0.5;
            mp1.xAxis = ChartsData.RainsYear.IndexOf(rainMax);
            mp1.symbolSize = 18;
            var mp2 = new MarkData("年最低");
            double rainMin = ChartsData.RainsYear.Min();
            mp2.Value(rainMin).YAxis(rainMin + 0.5).XAxis(ChartsData.RainsYear.IndexOf(rainMin));
            bar2.MarkPoint().Data(mp1, mp2);
            bar2.MarkLine().Data(new MarkData("平均值", MarkType.average));

            option.Series(bar1, bar2);

            var result = JsonTools.ObjectToJson2(option);
            return result;
        }

        [AcceptVerbs("GET", "POST")]
        [ActionName("bar2")]
        public string HeapColumn()
        {
            IList<string> ads = ChartsUtil.Ads();
            IList<string> ses = ChartsUtil.Ses();
            IList<int> data1 = ChartsUtil.Datas(7, 90, 240);
            IList<int> data2 = ChartsUtil.Datas(7, 190, 310);
            IList<int> data3 = ChartsUtil.Datas(7, 150, 410);
            IList<int> data4 = ChartsUtil.Datas(7, 300, 400);
            IList<int> data5 = ChartsUtil.Datas(7, 820, 1400);
            IList<int> data6 = ChartsUtil.Datas(7, 600, 1200);
            IList<int> data7 = ChartsUtil.Datas(7, 80, 400);
            IList<int> data8 = ChartsUtil.Datas(7, 100, 300);
            ads.ToList().AddRange(ses);
            ChartOption option = new ChartOption();
            option.ToolTip().Trigger(TriggerType.axis);
            option.Legend().SetData(new List<object>(ads.ToList()));
            option.ToolBox(ToolBox(OrientType.vertical));
            option.ToolBox().X(HorizontalType.right).Y(HorizontalType.center);
            option.calculable = true;
            var x = new CategoryAxis();
            x.SetData(ChartsUtil.Weeks().Cast<object>().ToList());
            option.XAxis(x);
            var y = new ValueAxis();
            option.YAxis(y);
            Bar b1 = new Bar(ads[0]);
            b1.stack = "广告";
            b1.data = data1;

            Bar b2 = new Bar(ads[1]);
            b2.stack = "广告";
            b2.data = data2;

            Bar b3 = new Bar(ads[2]);
            b3.stack = "广告";
            b3.data = data3;

            Bar b4 = new Bar(ads[3]);
            var mk1 = new MarkLine();
            mk1.ItemStyle().Normal().LineStyle().Type(LineStyleType.dashed);
            mk1.Data(new MarkData(MarkType.min), new MarkData(MarkType.max));
            b4.markLine = mk1;
            b4.data = data4;

            Bar b5 = new Bar(ads[4]);
            b5.stack = "搜索引擎";
            b5.data = data5;

            Bar b6 = new Bar(ses[0]);
            b6.stack = "搜索引擎";
            b6.data = data6;

            Bar b7 = new Bar(ses[1]);
            b7.stack = "搜索引擎";
            b7.data = data7;

            Bar b8 = new Bar(ses[2]);
            b8.stack = "搜索引擎";
            b8.data = data8;

            // option.Series<Line>(l1, l2, l3, l4, l5);
            option.Series(b1, b2, b3, b4, b5, b6, b7, b8);

            var result = JsonTools.ObjectToJson2(option);
            return result;

        }

        [AcceptVerbs("GET", "POST")]
        [ActionName("bar3")]
        public string StdBar()
        {
            ChartOption option = new ChartOption();
            option.Title().Text("世界人口总数").SubText("数据来源网络");
            option.ToolTip().Trigger(TriggerType.axis)
               .AxisPointer().Type(AxisPointType.shadow);
            option.Legend().Data("2011年", "2012年");
            option.ToolBox(ToolBox());
            option.calculable = true;
            var x = new ValueAxis();
            x.BoundaryGap(new List<double>() { 0, 0.01 });
            option.XAxis(x);
            var y = new CategoryAxis();
            y.SetData(new List<object>(ChartsUtil.Pops()));
            option.YAxis(y);
            var bar1 = new Bar("2011年");
            bar1.Data(18203, 23489, 29034, 104970, 131744, 630230);

            var bar2 = new Bar("2012年");
            bar2.Data(19325, 23438, 31000, 121594, 134141, 681807);

            option.Series(bar1, bar2);

            var result = JsonTools.ObjectToJson2(option);
            return result;
        }

        [AcceptVerbs("GET", "POST")]
        [ActionName("bar4")]
        public string HeapBar()
        {
            IList<string> ads = ChartsUtil.Ads();
            IList<int> data1 = ChartsUtil.Datas(7, 90, 240);
            IList<int> data2 = ChartsUtil.Datas(7, 190, 310);
            IList<int> data3 = ChartsUtil.Datas(7, 150, 410);
            IList<int> data4 = ChartsUtil.Datas(7, 300, 400);
            IList<int> data5 = ChartsUtil.Datas(7, 820, 1400);

            ChartOption option = new ChartOption();

            option.ToolTip().Trigger(TriggerType.axis).AxisPointer().Type(AxisPointType.shadow);
            option.Legend().SetData(new List<object>(ads.ToList()));
            option.ToolBox(ToolBox());

            option.calculable = true;
            var x = new ValueAxis();
            option.XAxis(x);

            var y = new CategoryAxis();
            y.data = new List<object>(ChartsUtil.Weeks());
            option.YAxis(y);

            var itemStyle = new ItemStyle();
            itemStyle.Normal().Label().Show(true).Position(StyleLabelTyle.insideRight);

            Bar b1 = new Bar(ads[0]);
            b1.stack = "总量";
            b1.itemStyle = itemStyle;
            b1.data = data1;

            Bar b2 = new Bar(ads[1]);
            b2.stack = "总量";
            b2.itemStyle = itemStyle;
            b2.data = data2;

            Bar b3 = new Bar(ads[2]);
            b3.stack = "总量";
            b3.itemStyle = itemStyle;
            b3.data = data3;

            Bar b4 = new Bar(ads[3]);
            b4.stack = "总量";
            b4.itemStyle = itemStyle;
            b4.data = data4;

            Bar b5 = new Bar(ads[4]);
            b5.stack = "总量";
            b5.itemStyle = itemStyle;
            b5.data = data5;



            // option.Series<Line>(l1, l2, l3, l4, l5);
            option.Series(b1, b2, b3, b4, b5);

            var result = JsonTools.ObjectToJson2(option);
            return result;

        }

        [AcceptVerbs("GET", "POST")]
        [ActionName("bar5")]
        public string StdWhirlwindBar()
        {
            IList<int> data1 = ChartsUtil.Datas(7, 220, 240);
            IList<int> data2 = ChartsUtil.Datas(7, 300, 500);
            IList<int> data3 = ChartsUtil.Datas(7, -250, -100);

            ChartOption option = new ChartOption();

            option.ToolTip().Trigger(TriggerType.axis).AxisPointer().Type(AxisPointType.shadow);
            option.Legend().Data("利润", "支出", "收入");

            Feature feature = new Feature();
            feature.Mark().Show(true);
            feature.DataView().Show(true).ReadOnly(false);
            feature.MagicType().Show(true).Type("line", "bar");
            feature.Restore().Show(true);
            feature.SaveAsImage().Show(true);            
            option.ToolBox().Show(true).SetFeature(feature);
            option.Calculable(true);
            ValueAxis x = new ValueAxis();
            option.XAxis(x);

            CategoryAxis y = new CategoryAxis();
            y.AxisTick().Show(false);
            y.SetData(ChartsUtil.Weeks().Cast<object>().ToList());
            option.YAxis(y);

            Bar b1 = new Bar("利润");
            b1.ItemStyle().Normal().Label().Show(true).Position(StyleLabelTyle.inside);
            b1.data = data1;

            Bar b2 = new Bar("收入");
            b2.Stack("总量").BarWidth(5).
                ItemStyle().Normal().Label().Show(true);
            b2.data = data2;

            Bar b3 = new Bar("支出");
            b3.Stack("总量").
                ItemStyle().Normal().Label().Show(true).Position(StyleLabelTyle.left);
            b3.data = data3;
            option.Series(b1, b2, b3);
            var result = JsonTools.ObjectToJson2(option);
            return result;

        }

        [AcceptVerbs("GET", "POST")]
        [ActionName("bar6")]
        public string VaryWaterfallBar()
        {
            ChartOption option = new ChartOption();
            option.Title().Text("阶梯瀑布图").Subtext("Form ExcelHome").
                Sublink("http://e.weibo.com/1341556070/Aj1J2x5a5");
            option.ToolTip().Trigger(TriggerType.axis)
                .Formatter(new JRaw(@"function (params) {
                    var tar;
                    if (params[1].value != '-') {
                        tar = params[1];
                    }
                    else {
                        tar = params[0];
                    }
                    return tar.name + '<br/>' + tar.seriesName + ' : ' + tar.value;
                  }"))
                .AxisPointer().Type(AxisPointType.shadow);
            option.Legend().Data("支出", "收入");
            Feature feature = new Feature();
            feature.Mark().Show(true);
            feature.DataView().Show(true).ReadOnly(false);
            feature.MagicType().Show(true).Type("line", "bar");
            feature.Restore().Show(true);
            feature.SaveAsImage().Show(true);
            option.ToolBox().Show(true).SetFeature(feature);
            CategoryAxis x = new CategoryAxis();
            x.SplitLine().Show(true);
            x.data = new JRaw(@"function (){
                var list = [];
                for (var i = 1; i <= 11; i++) {
                    list.push('11月' + i + '日');
                }
                return list;
            }()");
            option.XAxis(x);
            option.YAxis(new ValueAxis());
            Bar b1 = new Bar("辅助");
            b1.Stack("总量");
            var itemStyle = new ItemStyle();
            itemStyle.Normal().BarBorderColor("rgba(0,0,0,0)").Color("rgba(0,0,0,0)");
            itemStyle.Emphasis().BarBorderColor("rgba(0,0,0,0)").Color("rgba(0,0,0,0)");
            b1.SetItemStyle(itemStyle);
            b1.Data(0, 900, 1245, 1530, 1376, 1376, 1511, 1689, 1856, 1495, 1292);

            Bar b2 = new Bar("收入");
            b2.Stack("总量");
            b2.ItemStyle().Normal().Label().Show(true).Position(StyleLabelTyle.top);
            b2.Data(900, 345, 393, "-", "-", 135, 178, 286, "-", "-", "-");

            Bar b3 = new Bar("支出");
            b3.Stack("总量");
            b3.ItemStyle().Normal().Label().Show(true).Position(StyleLabelTyle.bottom);
            b3.Data("-", "-", "-", 108, 154, "-", "-", "-", 119, 361, 203);

            option.Series(b1, b2, b3);

            var result = JsonTools.ObjectToJson2(option);
            return result;
        }


        [AcceptVerbs("GET", "POST")]
        [ActionName("bar7")]
        public string CompWaterfallBar()
        {
            ChartOption option = new ChartOption();
            option.Title().Text("深圳月最低生活费组成（单位:元）").Subtext("Form ExcelHome").
                Sublink("http://e.weibo.com/1341556070/AjQH99che");
            option.ToolTip().Trigger(TriggerType.axis)
                .Formatter(new JRaw(@"function (params) {
            var tar = params[0];
            return tar.name + '<br/>' + tar.seriesName + ' : ' + tar.value;
                }"))
                .AxisPointer().Type(AxisPointType.shadow);
            
            Feature feature = new Feature();
            feature.Mark().Show(true);
            feature.DataView().Show(true).ReadOnly(false);
            feature.MagicType().Show(true).Type("line", "bar");
            feature.Restore().Show(true);
            feature.SaveAsImage().Show(true);
            option.ToolBox().Show(true).SetFeature(feature);
            CategoryAxis x = new CategoryAxis();
            x.SplitLine().Show(true);
            x.Data("总费用", "房租", "水电费", "交通费", "伙食费", "日用品数");
            option.XAxis(x);
            option.YAxis(new ValueAxis());
            Bar b1 = new Bar("辅助");
            b1.Stack("总量");
            var itemStyle = new ItemStyle();
            itemStyle.Normal().BarBorderColor("rgba(0,0,0,0)").Color("rgba(0,0,0,0)");
            itemStyle.Emphasis().BarBorderColor("rgba(0,0,0,0)").Color("rgba(0,0,0,0)");
            b1.SetItemStyle(itemStyle);
            b1.Data(0, 1700, 1400, 1200, 300, 0);

            Bar b2 = new Bar("生活费");
            b2.Stack("总量");
            b2.ItemStyle().Normal().Label().Show(true).Position(StyleLabelTyle.top);
            b2.Data(2900, 1200, 300, 200, 900, 300);            

            option.Series(b1, b2);

            var result = JsonTools.ObjectToJson2(option);
            return result;
        }

        [AcceptVerbs("GET", "POST")]
        [ActionName("bar8")]
        public string WhirlwindBar()
        {
            ChartOption option = new ChartOption();
            option.Title().Text("多维条形图").Subtext("Form ExcelHome").
                Sublink("http://e.weibo.com/1341556070/AiEscco0H");

            option.ToolTip().Trigger(TriggerType.axis)
               .AxisPointer().Type(AxisPointType.shadow);
            Feature feature = new Feature();
            feature.Mark().Show(true);
            feature.DataView().Show(true).ReadOnly(false);
            feature.MagicType().Show(true).Type("line", "bar");
            feature.Restore().Show(true);
            feature.SaveAsImage().Show(true);
            option.ToolBox().Show(true).SetFeature(feature);
            option.Grid().Y(80).Y2(30);
            ValueAxis x = new ValueAxis();
            x.Position(PositionType.top);
            x.SplitLine().LineStyle().Type(LineStyleType.dashed);
            option.XAxis(x);
            CategoryAxis y = new CategoryAxis();
            y.AxisLabel().Show(true);
            y.AxisLine().Show(true);
            y.AxisTick().Show(true);
            y.SplitLine().Show(true);
            y.Data("ten", "nine", "eight", "seven", "six", "five", "four", "three", "two", "one");
            option.YAxis(y);

            Bar b1 = new Bar("生活费");
            b1.Stack("总量");
            var itemStyle = new ItemStyle();
            itemStyle.Normal().Color("orange").BarBorderRadius(5)
                .Label().Show(true).Position(StyleLabelTyle.left).Formatter("{b}");
            b1.SetItemStyle(itemStyle);
            var labelRight = new ItemStyle();
            labelRight.Normal().Label().Position(StyleLabelTyle.right);
            SeriesData<double> sd1 = new SeriesData<double>(-0.07, labelRight);
            SeriesData<double> sd2 = new SeriesData<double>(-0.09, labelRight);
            SeriesData<double> sd3 = new SeriesData<double>(0.2);
            SeriesData<double> sd4 = new SeriesData<double>(0.44);
            SeriesData<double> sd5 = new SeriesData<double>(-0.23, labelRight);
            SeriesData<double> sd6 = new SeriesData<double>(0.08);
            SeriesData<double> sd7 = new SeriesData<double>(-0.17, labelRight);
            SeriesData<double> sd8 = new SeriesData<double>(0.47);
            SeriesData<double> sd9 = new SeriesData<double>(-0.36, labelRight);
            SeriesData<double> sd10 = new SeriesData<double>(0.18);
            b1.Data(sd1, sd2, sd4, sd5, sd6, sd7, sd8, sd9, sd10);
            option.Series(b1);
            var result = JsonTools.ObjectToJson2(option);
            return result;
        }

        [AcceptVerbs("GET", "POST")]
        [ActionName("bar10")]
        public string TemperatureBar()
        {
            ChartOption option = new ChartOption();
            option.Title().Text("温度计式图表").Subtext("Form ExcelHome").
                Sublink("http://e.weibo.com/1341556070/AizJXrAEa");
            option.ToolTip().Trigger(TriggerType.axis)
             .Formatter(new JRaw(@"function (params){
            return params[0].name + '<br/>'
                   + params[0].seriesName + ' : ' + params[0].value + '<br/>'
                   + params[1].seriesName + ' : ' + (params[1].value + params[0].value);
            }"))
             .AxisPointer().Type(AxisPointType.shadow);
            option.Legend().Data("Acutal","Forecast");
            Feature feature = new Feature();
            feature.Mark().Show(true);
            feature.DataView().Show(true).ReadOnly(false);
            feature.Restore().Show(true);
            feature.SaveAsImage().Show(true);
            option.ToolBox().Show(true).SetFeature(feature);
            option.Grid().Y(80).Y2(30);
            CategoryAxis x = new CategoryAxis();
            x.Data("Cosco", "CMA", "APL", "OOCL", "Wanhai", "Zim");
            option.XAxis(x);
            ValueAxis y = new ValueAxis();
            y.BoundaryGap(new List<double>() { 0,0.1 });           
            option.YAxis(y);

            var tomatoStyle = new ItemStyle();
            tomatoStyle.Normal().Color("tomato").BarBorderRadius(0)
                .BarBorderColor("tomato").BarBorderWidth(6)
                .Label().Show(true).Position(StyleLabelTyle.insideTop);
            Bar b1 = new Bar("Acutal");
            b1.Stack("sum");
            b1.SetItemStyle(tomatoStyle);            
            b1.Data(260, 200, 220, 120, 100, 80);

            var forecastStyle = new ItemStyle();
            forecastStyle.Normal().Color("#fff").BarBorderRadius(0)
                .BarBorderColor("tomato").BarBorderWidth(6)
                .Label().Show(true).Position(StyleLabelTyle.top)
                .Formatter(new JRaw(@"function (params) {
                            for (var i = 0, l = option.xAxis[0].data.length; i < l; i++) {
                                if (option.xAxis[0].data[i] == params.name) {
                                    return option.series[0].data[i] + params.value;
                                }
                            }
                        }"))
                        .TextStyle().Color("tomato");

            Bar b2 = new Bar("Forecast");
            b2.Stack("sum");
            b2.SetItemStyle(forecastStyle);
            b2.Data(40, 80, 50, 80, 80, 70);

            option.Series(b1, b2);

            var result = JsonTools.ObjectToJson2(option);
            return result;
        }

        [AcceptVerbs("GET", "POST")]
        [ActionName("bar11")]
        public string TimeColumn()
        {
            TimeLine time = new ECharts.Entities.TimeLine();
            time.Data("2002-01-01", "2003-01-01", "2004-01-01", "2005-01-01", "2006-01-01",
            "2007-01-01", "2008-01-01", "2009-01-01", "2010-01-01")
            .AutoPlay(true).PlayInterval(1000);
            time.Label().Formatter(new JRaw(@" function(s) {
                return s.slice(0, 4);
            }"));


          

            ChartOption option = new ChartOption();
            option.timeline = time;            

            ChartOption option1 = new ChartOption();
            option1.Title().Text("2002全国宏观经济指标").Subtext("数据来自国家统计局");
            option1.ToolTip().Trigger(TriggerType.axis);

            Dictionary<string, bool> selected = new Dictionary<string, bool>();
            selected.Add("GDP", true);
            selected.Add("金融", false);
            selected.Add("房地产", true);
            selected.Add("第一产业", false);
            selected.Add("第二产业", false);
            selected.Add("第三产业", false);
            option1.Legend().Data("GDP", "金融", "房地产", "第一产业", "第二产业", "第三产业")
                .X(HorizontalType.left).SetSelected(selected).X(HorizontalType.right);

            Feature feature = new Feature();
            feature.Mark().Show(true);
            feature.DataView().Show(true).ReadOnly(false);
            feature.Restore().Show(true);
            feature.SaveAsImage().Show(true);
            feature.MagicType().Show(true).Type("line", "bar", "stack", "tiled");
            option1.ToolBox().Show(true).Orient(OrientType.vertical)
                .X(HorizontalType.right).Y(HorizontalType.center).SetFeature(feature);                      
            option1.Grid().Y(80).Y2(100);

            CategoryAxis x = new CategoryAxis();
            x.Data("北京", "\n天津", "河北", "\n山西", "内蒙古", "\n辽宁", "吉林", "\n黑龙江",
                    "上海", "\n江苏", "浙江", "\n安徽", "福建", "\n江西", "山东", "\n河南",
                    "湖北", "\n湖南", "广东", "\n广西", "海南", "\n重庆", "四川", "\n贵州",
                    "云南", "\n西藏", "陕西", "\n甘肃", "青海", "\n宁夏", "新疆");
            x.AxisLabel().Interval(0);
            option1.XAxis(x);

            option1.Calculable(true);

            ValueAxis y1 = new ValueAxis();
            y1.Name("GDP(亿元)").Max(53500);
            ValueAxis y2 = new ValueAxis();
            y2.Name("其他(亿元)");            
            option1.YAxis(y1,y2);

            var lStyle = new LineStyle();
            lStyle.Color("orange");

            var mlStyle = new ItemStyle();            
            mlStyle.Normal().SetLineStyle(lStyle)
                .BarBorderColor("orange")
                .Label().Show(true).Position(StyleLabelTyle.left)
                .Formatter(new JRaw(@"function(params){
                                        return Math.round(params.value);
                                    }")).TextStyle().Color("orange");
            var ml = new MarkLine();
            ml.Symbol(new List<string>() { "arrow", "none" })
                .SetItemStyle(mlStyle);
            ml.symbolSize = new List<int> { 4, 2 };           
            ml.Data(new MarkData() { type = MarkType.average, name = "平均值" });

            Bar b1 = new Bar("GDP");            
            b1.markLine = ml;
            b1.data = new JRaw(@"dataMap.dataGDP['2002']");                       

            Bar b2 = new Bar("金融");
            b2.yAxisIndex = 1;         
            b2.data = new JRaw(@"dataMap.dataFinancial['2002']");


            Bar b3 = new Bar("房地产");
            b3.yAxisIndex = 1;
            b3.data =new JRaw(@"dataMap.dataEstate['2002']");


            Bar b4 = new Bar("第一产业");
            b4.yAxisIndex = 1;
            b4.data = new JRaw(@"dataMap.dataPI['2002']");


            Bar b5 = new Bar("第二产业");
            b5.yAxisIndex = 1;
            b5.data = new JRaw(@"dataMap.dataSI['2002']");


            Bar b6 = new Bar("第三产业");
            b6.yAxisIndex = 1;
            b6.data = new JRaw(@"dataMap.dataTI['2002']");

            option1.Series(b1, b2, b3, b4, b5, b6);

            IList<string> providers = new List<string>() {
                "dataMap.dataGDP",
                "dataMap.dataFinancial",
                "dataMap.dataEstate",
                "dataMap.dataPI",
                "dataMap.dataSI",
                "dataMap.dataTI"
            };


            ChartOption option2 = new ChartOption();
            option2.Title().Text("2003全国宏观经济指标");
            var d1 = ChartsUtil.EconDatas(2003, providers);

            option2.series = d1.Cast<object>().ToList();

            ChartOption option3 = new ChartOption();
            option3.Title().Text("2004全国宏观经济指标");
            var d2 = ChartsUtil.EconDatas(2004, providers);
                        
            option3.series = d2.Cast<object>().ToList(); 

            ChartOption option4 = new ChartOption();
            option4.Title().Text("2005全国宏观经济指标");

            var d3 = ChartsUtil.EconDatas(2005, providers);

            option4.series = d3.Cast<object>().ToList();

            ChartOption option5 = new ChartOption();
            option5.Title().Text("2006全国宏观经济指标");
            var d4 = ChartsUtil.EconDatas(2006, providers);

            option5.series = d4.Cast<object>().ToList();

            ChartOption option6 = new ChartOption();
            option6.Title().Text("2007全国宏观经济指标");
            var d5 = ChartsUtil.EconDatas(2007, providers);

            option6.series = d5.Cast<object>().ToList();

            ChartOption option7 = new ChartOption();
            option7.Title().Text("2008全国宏观经济指标");
            var d6 = ChartsUtil.EconDatas(2008, providers);

            option7.series = d6.Cast<object>().ToList();

            ChartOption option8 = new ChartOption();
            option8.Title().Text("2009全国宏观经济指标");
            var d7 = ChartsUtil.EconDatas(2009, providers);

            option8.series = d7.Cast<object>().ToList();

            ChartOption option9 = new ChartOption();
            option9.Title().Text("2010全国宏观经济指标");
            var d8 = ChartsUtil.EconDatas(2010, providers);

            option9.series = d8.Cast<object>().ToList();

            var options = new List<ChartOption>() {
                 option1,option2,option3,option4,option5,option7,
                 option8,option9
            };

            option.options = options;

            var result = JsonTools.ObjectToJson2(option);
            return result;
        }

        [AcceptVerbs("GET", "POST")]
        
        public string Bar()
        {
            ChartOption option = new ChartOption();
            option.Title().Text("世界人口总数").SubText("数据来源网络");
            option.ToolTip().Trigger(TriggerType.axis)
               .AxisPointer().Type(AxisPointType.shadow);
            option.Legend().Data("2011年","2012年");
            option.ToolBox(ToolBox());
            option.calculable = true;
            var x = new ValueAxis();
            x.BoundaryGap(new List<double>() { 0, 0.01 });
            option.XAxis(x);
            var y = new CategoryAxis();
            y.SetData(new List<object>(ChartsUtil.Pops()));
            option.YAxis(y);
            var bar1 = new Bar("2011年");
            bar1.Data(18203, 23489, 29034, 104970, 131744, 630230);
            
            var bar2 = new Bar("2012年");
            bar2.Data(19325, 23438, 31000, 121594, 134141, 681807);
         
            option.Series(bar1, bar2);

            var result = JsonTools.ObjectToJson2(option);
            return result;
        }

        //paired bars
        #endregion

        #region scatter data
        [AcceptVerbs("GET", "POST")]
        public string StdScatter()
        {
            ChartOption option = new ChartOption();
            option.Title().Text("男女身高体重分部").SubText("数据来源网络");
            option.ToolTip().Trigger(TriggerType.axis)
               .ShowDelay(0).Formatter(new JRaw(@" function (params) {
                if (params.value.length > 1) {
                    return params.seriesName + ' :<br/>'
                       + params.value[0] + 'cm ' 
                       + params.value[1] + 'kg ';
                }
                else {
                    return params.seriesName + ' :<br/>'
                       + params.name + ' : '
                       + params.value + 'kg ';
                }
            }"))
            .AxisPointer().Show(true).Type(AxisPointType.cross)
            .LineStyle().Type(LineStyleType.dashed).Width(1);

            option.Legend().Data("女性", "男性");

            option.ToolBox(ToolBox());
            option.calculable = true;

            var x = new ValueAxis();
            x.Scale(true).AxisLabel().Formatter(new JRaw("{value cm}").ToString());
            option.XAxis(x);
            var y = new ValueAxis();
            y.SetData(new List<object>(ChartsUtil.Pops()));
            option.YAxis(y);
            var s1 = new Scatter("女性");
            s1.SetData(ChartsData.females);
            s1.MarkPoint().Data(new MarkData("最大值", MarkType.max),new MarkData("最小值", MarkType.min));
            s1.MarkLine().Data(new MarkData("平均值", MarkType.average));
            
            var s2 = new Scatter("男性");
            s2.SetData(ChartsData.males);
            s2.MarkPoint().Data(new MarkData("最大值", MarkType.max), new MarkData("最小值", MarkType.min));
            s2.MarkLine().Data(new MarkData("平均值", MarkType.average));
            option.Series(s1, s2);

            var result = JsonTools.ObjectToJson2(option);
            return result;
        }
        #endregion

        #region pie data
        [AcceptVerbs("GET", "POST")]
        public string StdPie()
        {
            IList<string> ads = ChartsUtil.Ads();
           
            IList<int> data1 = ChartsUtil.Datas(7, 90, 240);
            IList<int> data2 = ChartsUtil.Datas(7, 190, 310);
            IList<int> data3 = ChartsUtil.Datas(7, 150, 410);
            IList<int> data4 = ChartsUtil.Datas(7, 300, 400);
             
            
            ChartOption option = new ChartOption();
            option.Title().Text("用户访问来源").SubText("虚构").X(HorizontalType.center);            
            option.ToolTip().Trigger(TriggerType.item).Formatter(new JRaw(@"{a} <br/>{b} : {c} ({d}%)").ToString());
            option.Legend().Orient(OrientType.vertical).X(HorizontalType.left).SetData(new List<object>(ads.ToList()));
            option.ToolBox(ToolBox(OrientType.vertical));
            option.ToolBox().X(HorizontalType.right).Y(HorizontalType.center);
            option.calculable = true;

            var pie = new Pie("访问来源");

            pie.Radius("55%").Center(new List<string>() { "50%", "60%" });
            pie.Data(new PieData<int>(345, ads[0]), new PieData<int>(310, ads[1]), new PieData<int>(234, ads[2]),
                new PieData<int>(135, ads[3]), new PieData<int>(1543, ads[4]));

            
            option.Series(pie);

            var result = JsonTools.ObjectToJson2(option);
            return result;

        }
        #endregion

        private ToolBox ToolBox(OrientType orient= OrientType.horizontal)
        {
            
            ToolBox tool = new ECharts.Entities.ToolBox();
            var feature = new Feature();
            feature.DataView().Show(true).ReadOnly(false);
            feature.Mark().Show(true);
            feature.Restore().Show(true);
            feature.MagicType().Show(true).Type("line", "bar", "stack", "tiled");
            feature.SaveAsImage().Show(true);
            tool.Show(true).SetFeature(feature);
            tool.Orient(orient);
            return tool;
        }

        [AcceptVerbs("GET", "POST")]
        public string Test()
        {
            IList<string> ads = ChartsUtil.Ads();

            IList<int> data1 = ChartsUtil.Datas(7, 90, 240);
            IList<int> data2 = ChartsUtil.Datas(7, 190, 310);
            IList<int> data3 = ChartsUtil.Datas(7, 150, 410);
            IList<int> data4 = ChartsUtil.Datas(7, 300, 400);


            ChartOption option = new ChartOption();
            option.Title().Text("用户访问来源").SubText("虚构").X(HorizontalType.center);
            option.ToolTip().Trigger(TriggerType.item).Formatter(new JRaw(@"{a} <br/>{b} : {c} ({d}%)").ToString());
            option.Legend().Orient(OrientType.vertical).X(HorizontalType.left).SetData(new List<object>(ads.ToList()));
            option.ToolBox(ToolBox(OrientType.vertical));
            option.ToolBox().X(HorizontalType.right).Y(HorizontalType.center);
            option.calculable = true;
  
           

            var pie = new Pie("访问来源");

            pie.Radius("55%").Center(new List<string>() { "50%", "60%" });
            pie.Data(new PieData<int>(345, ads[0]), new PieData<int>(310, ads[1]), new PieData<int>(234, ads[2]),
                new PieData<int>(135, ads[3]), new PieData<int>(1543, ads[4]));


            option.Series(pie);

            var result = JsonTools.ObjectToJson2(option);
            return result;

        }
    }
}
