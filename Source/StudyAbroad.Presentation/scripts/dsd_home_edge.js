/**
 * Adobe Edge: symbol definitions
 */
(function($, Edge, compId){
//images folder
var im='images/';

var fonts = {};
   fonts['\'Telex\', sans-serif']='';
   fonts['"Helvetica Neue", Helvetica, Arial, sans-serif']='';


var resources = [
];
var symbols = {
"stage": {
   version: "1.0.0",
   minimumCompatibleVersion: "0.1.7",
   build: "1.0.1.204",
   baseState: "Base State",
   initialState: "Base State",
   gpuAccelerate: false,
   resizeInstances: false,
   content: {
         dom: [
         {
            id:'about_case',
            type:'group',
            rect:['0px','378px','800','222','auto','auto'],
            c:[
            {
               id:'About_back',
               type:'rect',
               rect:['0px','222px','800px','300px','auto','auto'],
               fill:["rgba(255,255,255,1.00)"],
               stroke:[0,"rgb(0, 0, 0)","none"]
            },
            {
               id:'About_c',
               type:'text',
               rect:['32px','73px','auto','auto','auto','auto'],
               text:"This application is made as a project for Distributed Software Development Course 2012/2013 and race for SCORE competition. Travel 'n Study is designed and realized  by a  joint team iof students of FER university (Zagreb) and POLIMI university (Milan).",
               align:"left",
               font:['"Helvetica Neue", Helvetica, Arial, sans-serif',15,"rgba(85,85,85,1.00)","300","none","normal"]
            },
            {
               id:'About_h_underline',
               type:'rect',
               rect:['0px','55px','275px','2px','auto','auto'],
               fill:["rgba(85,85,85,1.00)"],
               stroke:[0,"rgba(0,0,0,1)","none"]
            },
            {
               id:'About_h',
               type:'text',
               rect:['70px','0px','auto','auto','auto','auto'],
               text:"About Us",
               align:"left",
               font:['Telex, sans-serif',50,"rgba(47,164,231,1.00)","500","none","normal"]
            }]
         },
         {
            id:'map_light_grey2',
            type:'image',
            rect:['400','300','1935px','1172px','auto','auto'],
            fill:["rgba(0,0,0,0)",im+"map_light_grey.jpg",'0px','0px']
         },
         {
            id:'explore_case',
            type:'group',
            rect:['0','-2px','800','229','auto','auto'],
            c:[
            {
               id:'explore_nav',
               type:'rect',
               rect:['0px','199px','800px','19px','auto','auto'],
               fill:["rgba(85,85,85,1)"],
               stroke:[0,"rgba(47, 164, 231, 0)","solid"]
            },
            {
               id:'explore_box',
               type:'rect',
               rect:['0px','0px','800px','200px','auto','auto'],
               fill:["rgba(245,245,245,1.00)"],
               stroke:[0,"rgba(47, 164, 231, 0)","solid"]
            },
            {
               id:'explore_u',
               type:'rect',
               rect:['0px','74px','200px','2px','auto','auto'],
               fill:["rgba(85,85,85,1.00)"],
               stroke:[0,"rgba(47, 164, 231, 0)","solid"]
            },
            {
               id:'explore_head',
               type:'text',
               rect:['100','24px','auto','auto','auto','auto'],
               text:"Explore",
               align:"left",
               font:['Telex, sans-serif',16,"rgba(85,85,85,1)","500","none","normal"]
            },
            {
               id:'explore_c',
               type:'text',
               rect:['66px','93px','632px','58px','auto','auto'],
               text:"freely browse over 11000 universities through our interactive map!",
               align:"left",
               font:['"Helvetica Neue", Helvetica, Arial, sans-serif',20,"rgba(85,85,85,1.00)","300","none","normal"]
            }]
         },
         {
            id:'suggestion_case',
            type:'group',
            rect:['-8px','85px','805','254','auto','auto'],
            c:[
            {
               id:'suggestion_back',
               type:'rect',
               rect:['-1px','90px','805px','0px','auto','auto'],
               fill:["rgba(245,245,245,1.00)"],
               stroke:[0,"rgba(47,164,231,1.00)","solid"]
            },
            {
               id:'suggestion_c',
               type:'text',
               rect:['74px','214px','713px','40px','auto','auto'],
               text:"Just answer few questions and we'll find the best suited university for you, through our advanced recommendation  mechanism.",
               align:"left",
               font:['"Helvetica Neue", Helvetica, Arial, sans-serif',18,"rgba(85,85,85,1.00)","300","none","normal"]
            },
            {
               id:'suggestion_u',
               type:'rect',
               rect:['8px','188px','296px','3px','auto','auto'],
               fill:["rgba(85,85,85,1.00)"],
               stroke:[0,"rgba(47,164,231,0.00)","solid"]
            },
            {
               id:'suggestion_heaer',
               type:'text',
               rect:['54px','139px','auto','auto','auto','auto'],
               text:"Suggestion",
               align:"center",
               font:['\'Telex\', sans-serif',50,"rgba(47,164,231,1.00)","500","none","normal"]
            },
            {
               id:'suggestion_intro',
               type:'text',
               rect:['93px','0px','630px','28px','auto','auto'],
               text:"Don't you have any idea of the place you want to go? Let us help you!",
               align:"center",
               font:['"Helvetica Neue", Helvetica, Arial, sans-serif',18,"rgba(85,85,85,1)","500","none","normal"]
            }]
         },
         {
            id:'menu',
            type:'group',
            rect:['0','570','800','30','auto','auto'],
            c:[
            {
               id:'menu_back',
               type:'rect',
               rect:['0px','0px','800px','30px','auto','auto'],
               fill:["rgba(85,85,85,1)"],
               stroke:[0,"rgb(0, 0, 0)","none"]
            },
            {
               id:'About_b',
               type:'ellipse',
               rect:['287px','4px','20px','20px','auto','auto'],
               borderRadius:["50%","50%","50%","50%"],
               opacity:0.3,
               fill:["rgba(0,0,0,1.00)"],
               stroke:[0,"rgb(0, 0, 0)","none"]
            },
            {
               id:'Suggest_b',
               type:'ellipse',
               rect:['362px','7px','15px','15px','auto','auto'],
               borderRadius:["50%","50%","50%","50%"],
               opacity:0.3,
               fill:["rgba(0,0,0,1.00)"],
               stroke:[0,"rgb(0, 0, 0)","none"]
            },
            {
               id:'Explore_b',
               type:'ellipse',
               rect:['392px','7px','15px','15px','auto','auto'],
               borderRadius:["50%","50%","50%","50%"],
               opacity:0.3,
               fill:["rgba(0,0,0,1.00)"],
               stroke:[0,"rgb(0, 0, 0)","none"]
            }]
         },
         {
            id:'subtitle',
            type:'text',
            rect:['147px','129px','643px','44px','auto','auto'],
            text:"So, what are you waiting for? Let's find the university that best suits your needs!<br>",
            align:"left",
            font:['"Helvetica Neue", Helvetica, Arial, sans-serif',18,"rgba(255,255,255,1)","normal","none","normal"]
         },
         {
            id:'title',
            type:'group',
            rect:['250px','60px','550','63','auto','auto'],
            c:[
            {
               id:'introducing',
               type:'text',
               rect:['0px','22px','auto','auto','auto','auto'],
               text:"Introducing",
               align:"left",
               font:['Arial, Helvetica, sans-serif',30,"rgba(85,85,85,1.00)","normal","none","normal"]
            },
            {
               id:'underline',
               type:'rect',
               rect:['0px','52px','538px','2px','auto','auto'],
               fill:["rgba(85,85,85,1.00)"],
               stroke:[0,"rgb(0, 0, 0)","none"]
            },
            {
               id:'studyAbroad',
               type:'text',
               rect:['551px','-2px','370px','63px','auto','auto'],
               text:"Travel 'n Study",
               align:"left",
               font:['Telex, sans-serif',50,"rgba(0,0,0,1)","600","none","normal"]
            }]
         }],
         symbolInstances: [

         ]
      },
   states: {
      "Base State": {
         "${_Explore_b}": [
            ["color", "background-color", 'rgba(0,0,0,1)'],
            ["style", "top", '7px'],
            ["style", "height", '15px'],
            ["style", "opacity", '0.30000001192092896'],
            ["style", "left", '392px'],
            ["style", "width", '15px']
         ],
         "${_menu_back}": [
            ["style", "height", '30px'],
            ["style", "opacity", '0'],
            ["style", "top", '0px'],
            ["style", "width", '800px']
         ],
         "${_underline}": [
            ["style", "top", '53.42px'],
            ["color", "background-color", 'rgba(85,85,85,1.00)'],
            ["style", "height", '2px'],
            ["style", "-webkit-transform-origin", [99999,24.28], {valueTemplate:'@@0@@% @@1@@%'} ],
            ["style", "-moz-transform-origin", [99999,24.28],{valueTemplate:'@@0@@% @@1@@%'}],
            ["style", "-ms-transform-origin", [99999,24.28],{valueTemplate:'@@0@@% @@1@@%'}],
            ["style", "msTransformOrigin", [99999,24.28],{valueTemplate:'@@0@@% @@1@@%'}],
            ["style", "-o-transform-origin", [99999,24.28],{valueTemplate:'@@0@@% @@1@@%'}],
            ["style", "left", '550px'],
            ["style", "width", '0px']
         ],
         "${_explore_nav}": [
            ["style", "top", '0px'],
            ["style", "opacity", '0'],
            ["style", "height", '30px'],
            ["color", "border-color", 'rgba(47, 164, 231, 0)'],
            ["style", "left", '0px'],
            ["style", "width", '800px']
         ],
         "${_explore_head}": [
            ["style", "top", '26px'],
            ["style", "font-weight", '500'],
            ["style", "font-family", 'Telex, sans-serif'],
            ["color", "color", 'rgba(47,164,231,1.00)'],
            ["style", "opacity", '0'],
            ["style", "left", '32px'],
            ["style", "font-size", '50px']
         ],
         "${_suggestion_heaer}": [
            ["style", "top", '141px'],
            ["style", "font-weight", '500'],
            ["style", "font-family", '\'Telex\', sans-serif'],
            ["color", "color", 'rgba(47,164,231,1.00)'],
            ["style", "opacity", '0'],
            ["style", "left", '58px'],
            ["style", "font-size", '50px']
         ],
         "${_Suggest_b}": [
            ["color", "background-color", 'rgba(0,0,0,1)'],
            ["style", "top", '6px'],
            ["style", "height", '15.075000286102px'],
            ["style", "opacity", '0.30000001192092896'],
            ["style", "left", '362px'],
            ["style", "width", '15px']
         ],
         "${_explore_u}": [
            ["color", "background-color", 'rgba(85,85,85,1.00)'],
            ["style", "height", '2px'],
            ["style", "top", '74px'],
            ["style", "left", '0px'],
            ["style", "width", '0px']
         ],
         "${_explore_c}": [
            ["color", "color", 'rgba(85,85,85,1.00)'],
            ["style", "opacity", '0'],
            ["style", "left", '66px'],
            ["style", "font-size", '18px'],
            ["style", "top", '93px'],
            ["style", "font-style", 'normal'],
            ["style", "font-family", '"Helvetica Neue", Helvetica, Arial, sans-serif'],
            ["style", "font-weight", '300'],
            ["style", "width", '631.93334960938px']
         ],
         "${_suggestion_intro}": [
            ["style", "opacity", '0'],
            ["style", "left", '93px'],
            ["style", "font-size", '18px'],
            ["style", "top", '0px'],
            ["style", "text-align", 'center'],
            ["style", "height", '28px'],
            ["style", "font-family", '"Helvetica Neue", Helvetica, Arial, sans-serif'],
            ["style", "font-weight", '500'],
            ["style", "width", '630.36663818359px']
         ],
         "${_title}": [
            ["style", "left", '250px']
         ],
         "${_subtitle}": [
            ["style", "top", '129.35px'],
            ["style", "font-size", '18px'],
            ["style", "height", '43.700000762939px'],
            ["style", "font-family", '"Helvetica Neue", Helvetica, Arial, sans-serif'],
            ["color", "color", 'rgba(85,85,85,1.00)'],
            ["style", "opacity", '0'],
            ["style", "left", '147px'],
            ["style", "width", '643px']
         ],
         "${_suggestion_u}": [
            ["color", "background-color", 'rgba(85,85,85,1.00)'],
            ["style", "top", '188.85px'],
            ["style", "border-width", '0px'],
            ["style", "height", '3px'],
            ["color", "border-color", 'rgba(47,164,231,0.00)'],
            ["style", "left", '8px'],
            ["style", "width", '0px']
         ],
         "${_About_h_underline}": [
            ["color", "background-color", 'rgba(85,85,85,1.00)'],
            ["style", "top", '71.67px'],
            ["style", "height", '2px'],
            ["style", "opacity", '1'],
            ["style", "left", '0px'],
            ["style", "width", '0px']
         ],
         "${_explore_box}": [
            ["color", "background-color", 'rgba(255,255,255,1.00)'],
            ["style", "top", '0px'],
            ["style", "left", '0.23px'],
            ["style", "height", '0px']
         ],
         "${_suggestion_back}": [
            ["style", "top", '215px'],
            ["color", "background-color", 'rgba(255,255,255,1.00)'],
            ["style", "left", '-8px'],
            ["style", "border-style", 'solid'],
            ["style", "height", '0px'],
            ["color", "border-color", 'rgba(85,85,85,1.00)'],
            ["style", "border-width", '0px'],
            ["style", "width", '818.17526530612px']
         ],
         "${_Stage}": [
            ["color", "background-color", 'rgba(255,255,255,1)'],
            ["style", "min-width", '600px'],
            ["style", "overflow", 'hidden'],
            ["style", "height", '600px'],
            ["style", "width", '800px']
         ],
         "${_About_c}": [
            ["color", "color", 'rgba(85,85,85,1.00)'],
            ["style", "opacity", '0'],
            ["style", "left", '32px'],
            ["style", "width", '736.40002441406px'],
            ["style", "top", '85.67px'],
            ["style", "height", '109.23958587646px'],
            ["style", "font-family", '"Helvetica Neue", Helvetica, Arial, sans-serif'],
            ["style", "font-weight", '300'],
            ["style", "font-size", '16px']
         ],
         "${_About_b}": [
            ["color", "background-color", 'rgba(0,0,0,1.00)'],
            ["style", "top", '7px'],
            ["style", "height", '15.075000286102px'],
            ["style", "opacity", '0.3'],
            ["style", "left", '422px'],
            ["style", "width", '15px']
         ],
         "${_map_light_grey2}": [
            ["style", "top", '62px'],
            ["style", "height", '430.71110026042px'],
            ["style", "opacity", '0'],
            ["style", "left", '0px'],
            ["style", "width", '800px']
         ],
         "${_explore_case}": [
            ["style", "top", '-2px']
         ],
         "${_introducing}": [
            ["style", "top", '22px'],
            ["style", "opacity", '0'],
            ["style", "left", '0px'],
            ["color", "color", 'rgba(85,85,85,1.00)']
         ],
         "${_About_h}": [
            ["style", "top", '22px'],
            ["style", "font-weight", '500'],
            ["style", "height", '58px'],
            ["style", "font-family", 'Telex, sans-serif'],
            ["color", "color", 'rgba(47,164,231,1.00)'],
            ["style", "opacity", '0'],
            ["style", "left", '32px'],
            ["style", "width", 'auto']
         ],
         "${_About_back}": [
            ["style", "top", '221.67px'],
            ["style", "height", '0px'],
            ["color", "background-color", 'rgba(255,255,255,1.00)'],
            ["style", "left", '0px'],
            ["style", "width", '800px']
         ],
         "${_menu}": [
            ["style", "top", '570px']
         ],
         "${_studyAbroad}": [
            ["style", "top", '0px'],
            ["style", "font-size", '50px'],
            ["style", "height", '63.200000762939px'],
            ["style", "font-family", 'Telex, sans-serif'],
            ["color", "color", 'rgba(47,164,231,1.00)'],
            ["style", "font-weight", '600'],
            ["style", "left", '551px'],
            ["style", "width", '377.69427490234px']
         ],
         "${_suggestion_c}": [
            ["color", "color", 'rgba(85,85,85,1.00)'],
            ["style", "opacity", '0'],
            ["style", "left", '74px'],
            ["style", "font-size", '18px'],
            ["style", "top", '214px'],
            ["style", "text-align", 'left'],
            ["style", "font-weight", '300'],
            ["style", "font-style", 'normal'],
            ["style", "font-family", '"Helvetica Neue", Helvetica, Arial, sans-serif'],
            ["style", "text-decoration", 'none'],
            ["style", "width", '712.88671875px']
         ]
      }
   },
   timelines: {
      "Default Timeline": {
         fromState: "Base State",
         toState: "",
         duration: 29807,
         autoPlay: true,
         labels: {
            "begin_intro": 0,
            "about_start": 7000,
            "about_stop": 10500,
            "suggestion_start": 14000,
            "suggestion_stop": 17750,
            "explore_start": 21497,
            "explore_stop": 25652,
            "finish": 29807
         },
         timeline: [
            { id: "eid268", tween: [ "style", "${_suggestion_back}", "border-width", '15px', { fromValue: '0px'}], position: 15500, duration: 1750, easing: "easeOutQuad" },
            { id: "eid501", tween: [ "style", "${_suggestion_back}", "border-width", '0px', { fromValue: '15px'}], position: 18250, duration: 1750, easing: "easeOutQuad" },
            { id: "eid68", tween: [ "style", "${_underline}", "width", '550px', { fromValue: '0px'}], position: 1000, duration: 1000 },
            { id: "eid342", tween: [ "style", "${_explore_u}", "width", '200px', { fromValue: '0px'}], position: 25356, duration: 296, easing: "easeInSine" },
            { id: "eid583", tween: [ "style", "${_explore_u}", "width", '0px', { fromValue: '200px'}], position: 25652, duration: 296, easing: "easeInSine" },
            { id: "eid123", tween: [ "style", "${_menu}", "top", '370px', { fromValue: '570px'}], position: 8000, duration: 2000, easing: "easeInSine" },
            { id: "eid437", tween: [ "style", "${_menu}", "top", '570px', { fromValue: '370px'}], position: 11000, duration: 2000, easing: "easeInSine" },
            { id: "eid132", tween: [ "style", "${_About_back}", "top", '21.67px', { fromValue: '221.67px'}], position: 8000, duration: 2000, easing: "easeInSine" },
            { id: "eid444", tween: [ "style", "${_About_back}", "top", '221.67px', { fromValue: '21.67px'}], position: 11000, duration: 2000, easing: "easeInSine" },
            { id: "eid74", tween: [ "style", "${_underline}", "left", '0px', { fromValue: '550px'}], position: 1000, duration: 1000 },
            { id: "eid131", tween: [ "style", "${_About_back}", "height", '200px', { fromValue: '0px'}], position: 8000, duration: 2000, easing: "easeInSine" },
            { id: "eid445", tween: [ "style", "${_About_back}", "height", '0px', { fromValue: '200px'}], position: 11000, duration: 2000, easing: "easeInSine" },
            { id: "eid605", tween: [ "style", "${_explore_head}", "left", '32px', { fromValue: '32px'}], position: 25652, duration: 0 },
            { id: "eid80", tween: [ "style", "${_introducing}", "opacity", '1', { fromValue: '0.000000'}], position: 2000, duration: 500 },
            { id: "eid633", tween: [ "style", "${_About_c}", "font-size", '16px', { fromValue: '16px'}], position: 10500, duration: 0 },
            { id: "eid225", tween: [ "color", "${_Suggest_b}", "background-color", 'rgba(47,164,231,1.00)', { animationColorSpace: 'RGB', valueTemplate: undefined, fromValue: 'rgba(0,0,0,1)'}], position: 14000, duration: 250, easing: "easeInSine" },
            { id: "eid510", tween: [ "color", "${_Suggest_b}", "background-color", 'rgba(0,0,0,1)', { animationColorSpace: 'RGB', valueTemplate: undefined, fromValue: 'rgba(47,164,231,1.00)'}], position: 21250, duration: 250, easing: "easeInSine" },
            { id: "eid141", tween: [ "color", "${_About_b}", "background-color", 'rgba(47,164,231,1.00)', { animationColorSpace: 'RGB', valueTemplate: undefined, fromValue: 'rgba(0,0,0,1)'}], position: 7000, duration: 250, easing: "easeInSine" },
            { id: "eid438", tween: [ "color", "${_About_b}", "background-color", 'rgba(0,0,0,1)', { animationColorSpace: 'RGB', valueTemplate: undefined, fromValue: 'rgba(47,164,231,1.00)'}], position: 13750, duration: 250, easing: "easeInSine" },
            { id: "eid513", tween: [ "style", "${_Suggest_b}", "top", '6px', { fromValue: '6px'}], position: 25652, duration: 0, easing: "easeInSine" },
            { id: "eid258", tween: [ "style", "${_suggestion_c}", "opacity", '1', { fromValue: '0.000000'}], position: 17500, duration: 250, easing: "easeOutQuad" },
            { id: "eid498", tween: [ "style", "${_suggestion_c}", "opacity", '0.000000', { fromValue: '1'}], position: 17750, duration: 250, easing: "easeOutQuad" },
            { id: "eid204", tween: [ "style", "${_map_light_grey2}", "height", '538.37501525879px', { fromValue: '430.71110026042px'}], position: 2500, duration: 1750, easing: "easeOutElastic" },
            { id: "eid604", tween: [ "style", "${_suggestion_heaer}", "left", '58px', { fromValue: '58px'}], position: 17750, duration: 0 },
            { id: "eid345", tween: [ "style", "${_explore_c}", "opacity", '1', { fromValue: '0.000000'}], position: 25356, duration: 296, easing: "easeInSine" },
            { id: "eid581", tween: [ "style", "${_explore_c}", "opacity", '0.000000', { fromValue: '1'}], position: 25652, duration: 296, easing: "easeInSine" },
            { id: "eid339", tween: [ "style", "${_explore_head}", "opacity", '1', { fromValue: '0'}], position: 25060, duration: 296, easing: "easeInSine" },
            { id: "eid582", tween: [ "style", "${_explore_head}", "opacity", '0', { fromValue: '1'}], position: 25948, duration: 296, easing: "easeInSine" },
            { id: "eid641", tween: [ "style", "${_subtitle}", "opacity", '1', { fromValue: '0'}], position: 4000, duration: 500 },
            { id: "eid179", tween: [ "style", "${_subtitle}", "opacity", '0', { fromValue: '1'}], position: 7000, duration: 1000 },
            { id: "eid436", tween: [ "style", "${_subtitle}", "opacity", '1', { fromValue: '0'}], position: 13000, duration: 1000 },
            { id: "eid224", tween: [ "style", "${_subtitle}", "opacity", '0', { fromValue: '1'}], position: 14000, duration: 1000 },
            { id: "eid507", tween: [ "style", "${_subtitle}", "opacity", '1', { fromValue: '0'}], position: 20497, duration: 1000 },
            { id: "eid300", tween: [ "style", "${_subtitle}", "opacity", '0', { fromValue: '1'}], position: 21497, duration: 1000 },
            { id: "eid579", tween: [ "style", "${_subtitle}", "opacity", '1', { fromValue: '0'}], position: 28807, duration: 1000 },
            { id: "eid626", tween: [ "style", "${_menu_back}", "opacity", '1', { fromValue: '0'}], position: 7500, duration: 500, easing: "easeOutQuad" },
            { id: "eid627", tween: [ "style", "${_menu_back}", "opacity", '0', { fromValue: '1'}], position: 13000, duration: 500, easing: "easeOutQuad" },
            { id: "eid320", tween: [ "style", "${_explore_box}", "height", '200px', { fromValue: '0px'}], position: 22997, duration: 2003, easing: "easeOutQuad" },
            { id: "eid572", tween: [ "style", "${_explore_box}", "height", '0px', { fromValue: '200px'}], position: 26250, duration: 2003, easing: "easeOutQuad" },
            { id: "eid611", tween: [ "style", "${_explore_c}", "font-size", '18px', { fromValue: '18px'}], position: 25652, duration: 0 },
            { id: "eid82", tween: [ "style", "${_studyAbroad}", "left", '162px', { fromValue: '551px'}], position: 2500, duration: 1500, easing: "easeOutElastic" },
            { id: "eid597", tween: [ "style", "${_About_h_underline}", "top", '71.67px', { fromValue: '71.67px'}], position: 4500, duration: 0 },
            { id: "eid476", tween: [ "style", "${_suggestion_u}", "top", '188.85px', { fromValue: '188.85px'}], position: 17750, duration: 0, easing: "easeOutQuad" },
            { id: "eid247", tween: [ "style", "${_suggestion_back}", "height", '200px', { fromValue: '0px'}], position: 15500, duration: 1750 },
            { id: "eid500", tween: [ "style", "${_suggestion_back}", "height", '0px', { fromValue: '200px'}], position: 18250, duration: 1750 },
            { id: "eid296", tween: [ "color", "${_Explore_b}", "background-color", 'rgba(47,164,231,1.00)', { animationColorSpace: 'RGB', valueTemplate: undefined, fromValue: 'rgba(0,0,0,1)'}], position: 21497, duration: 250, easing: "easeInSine" },
            { id: "eid637", tween: [ "color", "${_Explore_b}", "background-color", 'rgba(0,0,0,1)', { animationColorSpace: 'RGB', valueTemplate: undefined, fromValue: 'rgba(47,164,231,1.00)'}], position: 29557, duration: 250, easing: "easeInSine" },
            { id: "eid205", tween: [ "style", "${_map_light_grey2}", "opacity", '1', { fromValue: '0'}], position: 0, duration: 1250 },
            { id: "eid251", tween: [ "style", "${_suggestion_heaer}", "opacity", '1', { fromValue: '0.000000'}], position: 17250, duration: 250 },
            { id: "eid503", tween: [ "style", "${_suggestion_heaer}", "opacity", '0.000000', { fromValue: '1'}], position: 18000, duration: 250 },
            { id: "eid603", tween: [ "style", "${_suggestion_heaer}", "top", '141px', { fromValue: '141px'}], position: 17750, duration: 0 },
            { id: "eid609", tween: [ "color", "${_explore_box}", "background-color", 'rgba(255,255,255,1.00)', { animationColorSpace: 'RGB', valueTemplate: undefined, fromValue: 'rgba(255,255,255,1.00)'}], position: 24802, duration: 0 },
            { id: "eid323", tween: [ "style", "${_explore_box}", "top", '0px', { fromValue: '0px'}], position: 25060, duration: 0, easing: "easeOutQuad" },
            { id: "eid143", tween: [ "style", "${_Text5}", "top", '308.02px', { fromValue: '308.02px'}], position: 8500, duration: 0, easing: "easeInSine" },
            { id: "eid119", tween: [ "style", "${_title}", "left", '800px', { fromValue: '250px'}], position: 7000, duration: 1000 },
            { id: "eid435", tween: [ "style", "${_title}", "left", '250px', { fromValue: '800px'}], position: 13000, duration: 1000 },
            { id: "eid220", tween: [ "style", "${_title}", "left", '800px', { fromValue: '250px'}], position: 14000, duration: 1000 },
            { id: "eid509", tween: [ "style", "${_title}", "left", '250px', { fromValue: '800px'}], position: 20497, duration: 1000 },
            { id: "eid299", tween: [ "style", "${_title}", "left", '800px', { fromValue: '250px'}], position: 21497, duration: 1000 },
            { id: "eid578", tween: [ "style", "${_title}", "left", '250px', { fromValue: '800px'}], position: 28807, duration: 1000 },
            { id: "eid207", tween: [ "style", "${_map_light_grey2}", "width", '1001px', { fromValue: '800px'}], position: 2500, duration: 1750, easing: "easeOutElastic" },
            { id: "eid202", tween: [ "style", "${_map_light_grey2}", "top", '30px', { fromValue: '62px'}], position: 2500, duration: 1750, easing: "easeOutElastic" },
            { id: "eid203", tween: [ "style", "${_map_light_grey2}", "top", '-170px', { fromValue: '30px'}], position: 8000, duration: 2000, easing: "easeInSine" },
            { id: "eid439", tween: [ "style", "${_map_light_grey2}", "top", '30px', { fromValue: '-170px'}], position: 11000, duration: 2000, easing: "easeInSine" },
            { id: "eid322", tween: [ "style", "${_map_light_grey2}", "top", '230px', { fromValue: '30px'}], position: 22997, duration: 2003, easing: "easeOutQuad" },
            { id: "eid574", tween: [ "style", "${_map_light_grey2}", "top", '30px', { fromValue: '230px'}], position: 26250, duration: 2003, easing: "easeOutQuad" },
            { id: "eid142", tween: [ "style", "${_Text5}", "left", '49.44px', { fromValue: '49.44px'}], position: 8500, duration: 0, easing: "easeInSine" },
            { id: "eid308", tween: [ "style", "${_explore_nav}", "opacity", '1', { fromValue: '0'}], position: 22497, duration: 500, easing: "easeOutQuad" },
            { id: "eid614", tween: [ "style", "${_explore_nav}", "opacity", '0', { fromValue: '1'}], position: 28307, duration: 500, easing: "easeOutQuad" },
            { id: "eid306", tween: [ "style", "${_explore_nav}", "height", '30px', { fromValue: '30px'}], position: 22497, duration: 0, easing: "easeOutQuad" },
            { id: "eid181", tween: [ "style", "${_About_c}", "opacity", '0', { fromValue: '0'}], position: 0, duration: 0 },
            { id: "eid420", tween: [ "style", "${_About_c}", "opacity", '1', { fromValue: '0'}], position: 10250, duration: 250, easing: "easeInSine" },
            { id: "eid443", tween: [ "style", "${_About_c}", "opacity", '0', { fromValue: '1'}], position: 10500, duration: 250, easing: "easeInSine" },
            { id: "eid215", tween: [ "style", "${_About_c}", "opacity", '1', { fromValue: '0'}], position: 13000, duration: 0 },
            { id: "eid136", tween: [ "style", "${_About_h}", "opacity", '1', { fromValue: '0'}], position: 10000, duration: 250, easing: "easeInSine" },
            { id: "eid441", tween: [ "style", "${_About_h}", "opacity", '0', { fromValue: '1'}], position: 10750, duration: 250, easing: "easeInSine" },
            { id: "eid598", tween: [ "style", "${_About_h}", "left", '45px', { fromValue: '32px'}], position: 10250, duration: 250 },
            { id: "eid599", tween: [ "style", "${_About_h}", "left", '32px', { fromValue: '45px'}], position: 10500, duration: 250 },
            { id: "eid606", tween: [ "style", "${_explore_head}", "top", '26px', { fromValue: '26px'}], position: 25652, duration: 0 },
            { id: "eid418", tween: [ "style", "${_About_h_underline}", "width", '250px', { fromValue: '0px'}], position: 10250, duration: 250, easing: "easeInSine" },
            { id: "eid442", tween: [ "style", "${_About_h_underline}", "width", '0px', { fromValue: '250px'}], position: 10500, duration: 250, easing: "easeInSine" },
            { id: "eid239", tween: [ "style", "${_suggestion_intro}", "opacity", '1', { fromValue: '0'}], position: 15000, duration: 497 },
            { id: "eid508", tween: [ "style", "${_suggestion_intro}", "opacity", '0', { fromValue: '1'}], position: 20000, duration: 497 },
            { id: "eid248", tween: [ "style", "${_suggestion_back}", "top", '115px', { fromValue: '215px'}], position: 15500, duration: 1750 },
            { id: "eid502", tween: [ "style", "${_suggestion_back}", "top", '215px', { fromValue: '115px'}], position: 18250, duration: 1750 },
            { id: "eid206", tween: [ "style", "${_map_light_grey2}", "left", '-100px', { fromValue: '0px'}], position: 2500, duration: 1750, easing: "easeOutElastic" },
            { id: "eid316", tween: [ "style", "${_explore_nav}", "top", '200px', { fromValue: '0px'}], position: 22997, duration: 2003, easing: "easeOutQuad" },
            { id: "eid573", tween: [ "style", "${_explore_nav}", "top", '0px', { fromValue: '200px'}], position: 26250, duration: 2003, easing: "easeOutQuad" },
            { id: "eid585", tween: [ "style", "${_explore_nav}", "top", '2px', { fromValue: '0px'}], position: 28253, duration: 54, easing: "easeOutQuad" },
            { id: "eid256", tween: [ "style", "${_suggestion_u}", "width", '297px', { fromValue: '0px'}], position: 17500, duration: 250, easing: "easeOutQuad" },
            { id: "eid499", tween: [ "style", "${_suggestion_u}", "width", '0px', { fromValue: '297px'}], position: 17750, duration: 250, easing: "easeOutQuad" },
            { id: "eid303", tween: [ "color", "${_explore_nav}", "border-color", 'rgba(47, 164, 231, 0)', { animationColorSpace: 'RGB', valueTemplate: undefined, fromValue: 'rgba(47, 164, 231, 0)'}], position: 22497, duration: 0, easing: "easeOutQuad" },
            { id: "eid65", tween: [ "style", "${_underline}", "height", '2px', { fromValue: '2px'}], position: 1000, duration: 0 },
            { id: "eid77", tween: [ "style", "${_underline}", "height", '2px', { fromValue: '2px'}], position: 2000, duration: 0 },
            { id: "eid600", tween: [ "style", "${_About_h}", "top", '22px', { fromValue: '22px'}], position: 10500, duration: 0 }         ]
      }
   }
}
};


Edge.registerCompositionDefn(compId, symbols, fonts, resources);

/**
 * Adobe Edge DOM Ready Event Handler
 */
$(window).ready(function() {
     Edge.launchComposition(compId);
});
})(jQuery, AdobeEdge, "EDGE-731251");
