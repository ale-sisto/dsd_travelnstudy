/***********************
* Adobe Edge Animate Composition Actions
*
* Edit this file with caution, being careful to preserve 
* function signatures and comments starting with 'Edge' to maintain the 
* ability to interact with these actions from within Adobe Edge Animate
*
***********************/

var timeoutAction;

(function($, Edge, compId){
var Composition = Edge.Composition, Symbol = Edge.Symbol; // aliases for commonly used Edge classes

   //Edge symbol: 'stage'
   (function(symbolName) {
      
      
      

      

      Symbol.bindTriggerAction(compId, symbolName, "Default Timeline", 10500, function(sym, e) {
         sym.stop();

      });
      //Edge binding end

      Symbol.bindElementAction(compId, symbolName, "${_About_b}", "click", function(sym, e) {
         
         if (sym.getPosition() == sym.getLabelPosition("about_stop") ) {
         	clearTimeout(timeoutAction);
         	sym.play("about_stop");
         	}
         
         else if (sym.getPosition() ==  sym.getLabelPosition("suggestion_stop")) {
         	clearTimeout(timeoutAction);
         	sym.play("suggestion_stop");
         	timeoutAction = setTimeout(function() {
         									sym.stop("about_start"); 
         									sym.play();
         									}, 
         									sym.getLabelPosition("explore_start") - sym.getLabelPosition("suggestion_stop"));
         
         }
         
         else if (sym.getPosition() ==  sym.getLabelPosition("explore_stop"))
         {
         	clearTimeout(timeoutAction);
         	sym.play("explore_stop");
         	timeoutAction = setTimeout(function() {
         	sym.stop("about_start");
         	sym.play()
         	}, 
         	sym.getLabelPosition("finish") - sym.getLabelPosition("explore_stop"));
         
         }
         
         else {
         	clearTimeout(timeoutAction);
         	sym.stop("about_start"); 
         	sym.play();
         }
         
         
         

      });
      //Edge binding end

      Symbol.bindTriggerAction(compId, symbolName, "Default Timeline", 7000, function(sym, e) {
         sym.stop(7000);
         

      });
      //Edge binding end

      Symbol.bindTriggerAction(compId, symbolName, "Default Timeline", 29807, function(sym, e) {
         sym.stop();

      });
      //Edge binding end

      Symbol.bindTriggerAction(compId, symbolName, "Default Timeline", 25652, function(sym, e) {
         sym.stop();

      });
      //Edge binding end

      Symbol.bindTriggerAction(compId, symbolName, "Default Timeline", 21497, function(sym, e) {
         sym.stop();

      });
      //Edge binding end

      Symbol.bindTriggerAction(compId, symbolName, "Default Timeline", 17750, function(sym, e) {
         sym.stop();

      });
      //Edge binding end

      Symbol.bindTriggerAction(compId, symbolName, "Default Timeline", 14000, function(sym, e) {
         sym.stop();

      });
      //Edge binding end

      Symbol.bindElementAction(compId, symbolName, "${_Suggest_b}", "click", function(sym, e) {
         if (sym.getPosition() == sym.getLabelPosition("suggestion_stop") ) {
         	clearTimeout(timeoutAction);
         	sym.play("suggestion_stop");
         	}
         
         else if (sym.getPosition() ==  sym.getLabelPosition("explore_stop")) {
         	clearTimeout(timeoutAction);
         	sym.play("explore_stop");
         	timeoutAction = setTimeout(function() {
         									sym.stop("suggestion_start"); 
         									sym.play();
         									}, 
         									sym.getLabelPosition("finish") - sym.getLabelPosition("explore_stop"));
         
         }
         
         else if (sym.getPosition() ==  sym.getLabelPosition("about_stop")) {
         	clearTimeout(timeoutAction);
         	sym.play("about_stop");
         	timeoutAction = setTimeout(function() {
         	sym.stop("suggestion_start");
         	sym.play()
         	}, 
         	sym.getLabelPosition("suggestion_start") - sym.getLabelPosition("about_stop"));
         
         }
         
         else {
         	clearTimeout(timeoutAction);
         	sym.stop("suggestion_start");
         	sym.play()
         }

      });
      //Edge binding end

      Symbol.bindElementAction(compId, symbolName, "${_Explore_b}", "click", function(sym, e) {
         if (sym.getPosition() == sym.getLabelPosition("explore_stop") ) {
         	clearTimeout(timeoutAction);
         	sym.play("explore_stop");
         	}
         
         else if (sym.getPosition() ==  sym.getLabelPosition("suggestion_stop")) {
         	clearTimeout(timeoutAction);
         	sym.play("suggestion_stop");
         	timeoutAction = setTimeout(function() {
         									sym.stop("explore_start"); 
         									sym.play();
         									}, 
         									sym.getLabelPosition("explore_start") - sym.getLabelPosition("suggestion_stop"));
         
         }
         
         else if (sym.getPosition() ==  sym.getLabelPosition("about_stop")) {
         	clearTimeout(timeoutAction);
         	sym.play("about_stop");
         	timeoutAction = setTimeout(function() {
         	sym.stop("explore_start");
         	sym.play()
         	}, 
         	sym.getLabelPosition("suggestion_start") - sym.getLabelPosition("about_stop"));
         
         }
         
         else {
         	clearTimeout(timeoutAction);
         	sym.stop("explore_start");
         	sym.play()
         }

      });
      //Edge binding end

      Symbol.bindTriggerAction(compId, symbolName, "Default Timeline", 4500, function(sym, e) {
         sym.stop();

      });
      //Edge binding end

      Symbol.bindElementAction(compId, symbolName, "${_Explore_b}", "mouseover", function(sym, e) {
         $(this.lookupSelector("Explore_b")).css('cursor','pointer');

      });
      //Edge binding end

      Symbol.bindElementAction(compId, symbolName, "${_Suggest_b}", "mouseover", function(sym, e) {
         $(this.lookupSelector("Suggest_b")).css('cursor','pointer');

      });
      //Edge binding end

      Symbol.bindElementAction(compId, symbolName, "${_About_b}", "mouseover", function(sym, e) {
         $(this.lookupSelector("About_b")).css('cursor','pointer');

      });
      //Edge binding end

   })("stage");
   //Edge symbol end:'stage'

})(jQuery, AdobeEdge, "EDGE-731251");