!function(i){var o,t,n,r,e,a,s;i.document&&((o=i.document).querySelectorAll||(o.querySelectorAll=function(e){var t,n=o.createElement("style"),r=[];for(o.documentElement.firstChild.appendChild(n),o._qsa=[],n.styleSheet.cssText=e+"{x-qsa:expression(document._qsa && document._qsa.push(this))}",i.scrollBy(0,0),n.parentNode.removeChild(n);o._qsa.length;)(t=o._qsa.shift()).style.removeAttribute("x-qsa"),r.push(t);return o._qsa=null,r}),o.querySelector||(o.querySelector=function(e){e=o.querySelectorAll(e);return e.length?e[0]:null}),o.getElementsByClassName||(o.getElementsByClassName=function(e){return e=String(e).replace(/^|\s+/g,"."),o.querySelectorAll(e)}),Object.keys||(Object.keys=function(e){if(e!==Object(e))throw TypeError("Object.keys called on non-object");var t,n=[];for(t in e)Object.prototype.hasOwnProperty.call(e,t)&&n.push(t);return n}),Array.prototype.forEach||(Array.prototype.forEach=function(e){if(null==this)throw TypeError();var t=Object(this),n=t.length>>>0;if("function"!=typeof e)throw TypeError();for(var r=arguments[1],i=0;i<n;i++)i in t&&e.call(r,t[i],i,t)}),s="ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789+/=",(a=i).atob=a.atob||function(e){var t=0,n=[],r=0,i=0;if((e=(e=(e=String(e)).replace(/\s/g,"")).length%4==0?e.replace(/=+$/,""):e).length%4==1)throw Error("InvalidCharacterError");if(/[^+\/0-9A-Za-z]/.test(e))throw Error("InvalidCharacterError");for(;t<e.length;)r=r<<6|s.indexOf(e.charAt(t)),24===(i+=6)&&(n.push(String.fromCharCode(r>>16&255)),n.push(String.fromCharCode(r>>8&255)),n.push(String.fromCharCode(255&r)),r=i=0),t+=1;return 12===i?(r>>=4,n.push(String.fromCharCode(255&r))):18===i&&(r>>=2,n.push(String.fromCharCode(r>>8&255)),n.push(String.fromCharCode(255&r))),n.join("")},a.btoa=a.btoa||function(e){e=String(e);var t,n,r,i,o=0,a=[];if(/[^\x00-\xFF]/.test(e))throw Error("InvalidCharacterError");for(;o<e.length;)n=(3&(t=e.charCodeAt(o++)))<<4|(i=e.charCodeAt(o++))>>4,r=(15&i)<<2|(i=e.charCodeAt(o++))>>6,i=63&i,o===e.length+2?i=r=64:o===e.length+1&&(i=64),a.push(s.charAt(t>>2),s.charAt(n),s.charAt(r),s.charAt(i));return a.join("")},Object.prototype.hasOwnProperty||(Object.prototype.hasOwnProperty=function(e){var t=this.__proto__||this.constructor.prototype;return e in this&&(!(e in t)||t[e]!==this[e])}),"performance"in i==0&&(i.performance={}),Date.now=Date.now||function(){return(new Date).getTime()},"now"in i.performance==0&&(e=Date.now(),performance.timing&&performance.timing.navigationStart&&(e=performance.timing.navigationStart),i.performance.now=function(){return Date.now()-e}),i.requestAnimationFrame||(i.webkitRequestAnimationFrame&&i.webkitCancelAnimationFrame?((r=i).requestAnimationFrame=function(e){return webkitRequestAnimationFrame(function(){e(r.performance.now())})},r.cancelAnimationFrame=r.webkitCancelAnimationFrame):i.mozRequestAnimationFrame&&i.mozCancelAnimationFrame?((n=i).requestAnimationFrame=function(e){return mozRequestAnimationFrame(function(){e(n.performance.now())})},n.cancelAnimationFrame=n.mozCancelAnimationFrame):((t=i).requestAnimationFrame=function(e){return t.setTimeout(e,1e3/60)},t.cancelAnimationFrame=t.clearTimeout)))}(this),function(e,t){"object"==typeof exports&&"object"==typeof module?module.exports=t():"function"==typeof define&&define.amd?define([],t):"object"==typeof exports?exports.Holder=t():e.Holder=t()}(this,function(){return r=[function(e,t,n){e.exports=n(1)},function(j,e,O){!function(l){function c(e,t,n,r){n=i(n.substr(n.lastIndexOf(e.domain)),e);n&&o({mode:null,el:r,flags:n,engineSettings:t})}function i(e,t){var t={theme:x(k.settings.themes.gray,null),stylesheets:t.stylesheets,instanceOptions:t},n=e.indexOf("?"),r=[e],n=(r=-1!==n?[e.slice(0,n),e.slice(n+1)]:r)[0].split("/"),e=(t.holderURL=e,n[1]),n=e.match(/([\d]+p?)x([\d]+p?)/);return!!n&&(t.fluid=-1!==e.indexOf("p"),t.dimensions={width:n[1].replace("p","%"),height:n[2].replace("p","%")},2===r.length&&(e=a.parse(r[1]),m.truthy(e.ratio)&&(t.fluid=!0,n=parseFloat(t.dimensions.width.replace("%","")),r=parseFloat(t.dimensions.height.replace("%","")),r=Math.floor(r/n*100),n=100,t.dimensions.width="100%",t.dimensions.height=r+"%"),t.auto=m.truthy(e.auto),e.bg&&(t.theme.bg=m.parseColor(e.bg)),e.fg&&(t.theme.fg=m.parseColor(e.fg)),e.bg&&!e.fg&&(t.autoFg=!0),e.theme&&t.instanceOptions.themes.hasOwnProperty(e.theme)&&(t.theme=x(t.instanceOptions.themes[e.theme],null)),e.text&&(t.text=e.text),e.textmode&&(t.textmode=e.textmode),e.size&&parseFloat(e.size)&&(t.size=parseFloat(e.size)),e.font&&(t.font=e.font),e.align&&(t.align=e.align),e.lineWrap&&(t.lineWrap=e.lineWrap),t.nowrap=m.truthy(e.nowrap),t.outline=m.truthy(e.outline),m.truthy(e.random))&&(k.vars.cache.themeKeys=k.vars.cache.themeKeys||Object.keys(t.instanceOptions.themes),n=k.vars.cache.themeKeys[0|Math.random()*k.vars.cache.themeKeys.length],t.theme=x(t.instanceOptions.themes[n],null)),t)}function o(e){var t=e.mode,n=e.el,r=e.flags,e=e.engineSettings,i=r.dimensions,o=r.theme,a=i.width+"x"+i.height,t=null==t?r.fluid?"fluid":"image":t;if(null!=r.text&&(o.text=r.text,"object"===n.nodeName.toLowerCase())){for(var s=o.text.split("\\n"),l=0;l<s.length;l++)s[l]=m.encodeHtmlEntity(s[l]);o.text=s.join("\\n")}o.text&&null!==(d=o.text.match(/holder_([a-z]+)/g))&&d.forEach(function(e){"holder_dimensions"===e&&(o.text=o.text.replace(e,a))});var h,d=r.holderURL,e=x(e,null),d=(r.font&&(o.font=r.font,!e.noFontFallback)&&"img"===n.nodeName.toLowerCase()&&k.setup.supportsCanvas&&"svg"===e.renderer&&(e=x(e,{renderer:"canvas"})),r.font&&"canvas"==e.renderer&&(e.reRender=!0),"background"==t?null==n.getAttribute("data-background-src")&&y.setAttr(n,{"data-background-src":d}):((h={})[k.vars.dataAttr]=d,y.setAttr(n,h)),r.theme=o,n.holderData={flags:r,engineSettings:e},"image"!=t&&"fluid"!=t||y.setAttr(n,{alt:o.text?o.text+" ["+a+"]":a}),{mode:t,el:n,holderSettings:{dimensions:i,theme:o,flags:r},engineSettings:e});"image"==t?(r.auto||(n.style.width=i.width+"px",n.style.height=i.height+"px"),"html"==e.renderer?n.style.backgroundColor=o.bg:(u(d),"exact"==r.textmode&&(n.holderData.resizeUpdate=!0,k.vars.resizableImages.push(n),f(n)))):"background"==t&&"html"!=e.renderer?u(d):"fluid"==t&&(n.holderData.resizeUpdate=!0,"%"==i.height.slice(-1)?n.style.height=i.height:null!=r.auto&&r.auto||(n.style.height=i.height+"px"),"%"==i.width.slice(-1)?n.style.width=i.width:null!=r.auto&&r.auto||(n.style.width=i.width+"px"),"inline"!=n.style.display&&""!==n.style.display&&"none"!=n.style.display||(n.style.display="block"),(h=n).holderData&&((d=C(h))?(t=h.holderData.flags,(d={fluidHeight:"%"==t.dimensions.height.slice(-1),fluidWidth:"%"==t.dimensions.width.slice(-1),mode:null,initialDimensions:d}).fluidWidth&&!d.fluidHeight?(d.mode="width",d.ratio=d.initialDimensions.width/parseFloat(t.dimensions.height)):!d.fluidWidth&&d.fluidHeight&&(d.mode="height",d.ratio=parseFloat(t.dimensions.width)/d.initialDimensions.height),h.holderData.fluidConfig=d):p(h)),"html"==e.renderer?n.style.backgroundColor=o.bg:(k.vars.resizableImages.push(n),f(n)))}function u(t){function n(){var e=null;switch(o.renderer){case"canvas":e=b(s,t);break;case"svg":e=w(s,t);break;default:throw"Holder: invalid renderer: "+o.renderer}return e}var e=t.mode,r=t.el,i=t.holderSettings,o=t.engineSettings;switch(o.renderer){case"svg":if(k.setup.supportsSVG)break;return;case"canvas":if(k.setup.supportsCanvas)break;return;default:return}var a,i={width:i.dimensions.width,height:i.dimensions.height,theme:i.theme,flags:i.flags},s=function(e){function t(e,t,n,r){t.width=n,t.height=r,e.width=Math.max(e.width,t.width),e.height+=t.height}var n=k.defaults.size;switch(parseFloat(e.theme.size)?n=e.theme.size:parseFloat(e.flags.size)&&(n=e.flags.size),e.font={family:e.theme.font||"Arial, Helvetica, Open Sans, sans-serif",size:function(e,t,n,r){var e=parseInt(e,10),t=parseInt(t,10),i=Math.max(e,t),e=Math.min(e,t),t=.8*Math.min(e,i*r);return Math.round(Math.max(n,t))}(e.width,e.height,n,k.defaults.scale),units:e.theme.units||k.defaults.units,weight:e.theme.fontweight||"bold"},e.text=e.theme.text||Math.floor(e.width)+"x"+Math.floor(e.height),e.noWrap=e.theme.nowrap||e.flags.nowrap,e.align=e.theme.align||e.flags.align||"center",e.flags.textmode){case"literal":e.text=e.flags.dimensions.width+"x"+e.flags.dimensions.height;break;case"exact":e.flags.exactDimensions&&(e.text=Math.floor(e.flags.exactDimensions.width)+"x"+Math.floor(e.flags.exactDimensions.height))}var n=e.flags.lineWrap||k.setup.lineWrapRatio,r=e.width*n,i=r,o=new S({width:e.width,height:e.height}),a=o.Shape,s=new a.Rect("holderBg",{fill:e.theme.bg});s.resize(e.width,e.height),o.root.add(s),e.flags.outline&&(l=(l=new A(s.properties.fill)).lighten(l.lighterThan("7f7f7f")?-.1:.1),s.properties.outline={fill:l.toHex(!0),width:2});var l=e.theme.fg;{var h,d;e.flags.autoFg&&(s=new A(s.properties.fill),h=new A("fff"),d=new A("000",{alpha:.285714}),l=s.blendAlpha(s.lighterThan("7f7f7f")?d:h).toHex(!0))}var c=new a.Group("holderTextGroup",{text:e.text,align:e.align,font:e.font,fill:l}),u=(c.moveTo(null,null,1),o.root.add(c),c.textPositionData=F(o));if(!u)throw"Holder: staging fallback not supported yet.";c.properties.leading=u.boundingBox.height;var f=null,p=null;if(1<u.lineCount){var g,m=0,v=0,y=0;p=new a.Group("line"+y),"left"!==e.align&&"right"!==e.align||(i=e.width*(1-2*(1-n)));for(var w=0;w<u.words.length;w++){var b=u.words[w],x=(f=new a.Text(b.text),"\\n"==b.text);!e.noWrap&&(m+b.width>=i||!0==x)&&(t(c,p,m,c.properties.leading),c.add(p),m=0,v+=c.properties.leading,y+=1,(p=new a.Group("line"+y)).y=v),!0!=x&&(f.moveTo(m,0),m+=u.spaceWidth+b.width,p.add(f))}if(t(c,p,m,c.properties.leading),c.add(p),"left"===e.align)c.moveTo(e.width-r,null,null);else if("right"===e.align){for(g in c.children)p=c.children[g],p.moveTo(e.width-p.width,null,null);c.moveTo(0-(e.width-r),null,null)}else{for(g in c.children)p=c.children[g],p.moveTo((c.width-p.width)/2,null,null);c.moveTo((e.width-c.width)/2,null,null)}c.moveTo(null,(e.height-c.height)/2,null),(e.height-c.height)/2<0&&c.moveTo(null,0,null)}else f=new a.Text(e.text),(p=new a.Group("line0")).add(f),c.add(p),"left"===e.align?c.moveTo(e.width-r,null,null):"right"===e.align?c.moveTo(0-(e.width-r),null,null):c.moveTo((e.width-u.boundingBox.width)/2,null,null),c.moveTo(null,(e.height-u.boundingBox.height)/2,null);return o}(i);if(null==(a=n()))throw"Holder: couldn't render placeholder";"background"==e?(r.style.backgroundImage="url("+a+")",o.noBackgroundSize||(r.style.backgroundSize=i.width+"px "+i.height+"px")):("img"===r.nodeName.toLowerCase()?y.setAttr(r,{src:a}):"object"===r.nodeName.toLowerCase()&&y.setAttr(r,{data:a,type:"image/svg+xml"}),o.reRender&&l.setTimeout(function(){var e=n();if(null==e)throw"Holder: couldn't render placeholder";"img"===r.nodeName.toLowerCase()?y.setAttr(r,{src:e}):"object"===r.nodeName.toLowerCase()&&y.setAttr(r,{data:e,type:"image/svg+xml"})},150)),y.setAttr(r,{"data-holder-rendered":!0})}function f(e){for(var t=null==e||null==e.nodeType?k.vars.resizableImages:[e],n=0,r=t.length;n<r;n++){var i=t[n];if(i.holderData){var o=i.holderData.flags,a=C(i);if(a){if(i.holderData.resizeUpdate){if(o.fluid&&o.auto){var s=i.holderData.fluidConfig;switch(s.mode){case"width":a.height=a.width/s.ratio;break;case"height":a.width=a.height*s.ratio}}var l={mode:"image",holderSettings:{dimensions:a,theme:o.theme,flags:o},el:i,engineSettings:i.holderData.engineSettings};"exact"==o.textmode&&(o.exactDimensions=a,l.holderSettings.dimensions=o.dimensions),u(l)}}else p(i)}}}function e(){var t,n=[];Object.keys(k.vars.invisibleImages).forEach(function(e){t=k.vars.invisibleImages[e],C(t)&&"img"==t.nodeName.toLowerCase()&&(n.push(t),delete k.vars.invisibleImages[e])}),n.length&&T.run({images:n}),setTimeout(function(){l.requestAnimationFrame(e)},10)}function p(e){e.holderData.invisibleId||(k.vars.invisibleId+=1,(k.vars.invisibleImages["i"+k.vars.invisibleId]=e).holderData.invisibleId=k.vars.invisibleId)}function t(){!function(e){k.vars.debounceTimer||e.call(this),k.vars.debounceTimer&&l.clearTimeout(k.vars.debounceTimer),k.vars.debounceTimer=l.setTimeout(function(){k.vars.debounceTimer=null,e.call(this)},k.setup.debounce)}(function(){f(null)})}var h,d,g,n,r=O(2),a=O(3),S=O(6),m=O(7),v=O(8),y=O(9),A=O(10),s=O(11),w=O(12),b=O(15),x=m.extend,C=m.dimensionCheck,E=s.svg_ns,T={version:s.version,addTheme:function(e,t){return null!=e&&null!=t&&(k.settings.themes[e]=t),delete k.vars.cache.themeKeys,this},addImage:function(r,e){return y.getNodeArray(e).forEach(function(e){var t=y.newEl("img"),n={};n[k.setup.dataAttr]=r,y.setAttr(t,n),e.appendChild(t)}),this},setResizeUpdate:function(e,t){e.holderData&&(e.holderData.resizeUpdate=!!t,e.holderData.resizeUpdate)&&f(e)},run:function(e){var h={},d=x(k.settings,e=e||{}),e=(k.vars.preempted=!0,k.vars.dataAttr=d.dataAttr||k.setup.dataAttr,h.renderer=d.renderer||k.setup.renderer,-1===k.setup.renderers.join(",").indexOf(h.renderer)&&(h.renderer=k.setup.supportsSVG?"svg":k.setup.supportsCanvas?"canvas":"html"),y.getNodeArray(d.images)),t=y.getNodeArray(d.bgnodes),n=y.getNodeArray(d.stylenodes),r=y.getNodeArray(d.objects);return h.stylesheets=[],h.svgXMLStylesheet=!0,h.noFontFallback=!!d.noFontFallback,h.noBackgroundSize=!!d.noBackgroundSize,n.forEach(function(e){var t;e.attributes.rel&&e.attributes.href&&"stylesheet"==e.attributes.rel.value&&(e=e.attributes.href.value,(t=y.newEl("a")).href=e,e=t.protocol+"//"+t.host+t.pathname+t.search,h.stylesheets.push(e))}),t.forEach(function(e){if(l.getComputedStyle){var t=l.getComputedStyle(e,null).getPropertyValue("background-image"),t=e.getAttribute("data-background-src")||t,n=null,r=d.domain+"/",r=t.indexOf(r);if(0===r)n=t;else if(1===r&&"?"===t[0])n=t.slice(1);else{r=t.substr(r).match(/([^\"]*)"?\)/);if(null!==r)n=r[1];else if(0===t.indexOf("url("))throw"Holder: unable to parse background URL: "+t}n&&(r=i(n,d))&&o({mode:"background",el:e,flags:r,engineSettings:h})}}),r.forEach(function(e){var t={};try{t.data=e.getAttribute("data"),t.dataSrc=e.getAttribute(k.vars.dataAttr)}catch(e){}var n=null!=t.data&&0===t.data.indexOf(d.domain),r=null!=t.dataSrc&&0===t.dataSrc.indexOf(d.domain);n?c(d,h,t.data,e):r&&c(d,h,t.dataSrc,e)}),e.forEach(function(e){var t={};try{t.src=e.getAttribute("src"),t.dataSrc=e.getAttribute(k.vars.dataAttr),t.rendered=e.getAttribute("data-holder-rendered")}catch(e){}var n,r,i,o,a=null!=t.src,s=null!=t.dataSrc&&0===t.dataSrc.indexOf(d.domain),l=null!=t.rendered&&"true"==t.rendered;a?0===t.src.indexOf(d.domain)?c(d,h,t.src,e):s&&(l?c(d,h,t.dataSrc,e):(n=d,r=h,i=t.dataSrc,o=e,m.imageExists(t.src,function(e){e||c(n,r,i,o)}))):s&&c(d,h,t.dataSrc,e)}),this}},k={settings:{domain:"holder.js",images:"img",objects:"object",bgnodes:"body .holderjs",stylenodes:"head link.holderjs",themes:{gray:{bg:"#EEEEEE",fg:"#AAAAAA"},social:{bg:"#3a5a97",fg:"#FFFFFF"},industrial:{bg:"#434A52",fg:"#C2F200"},sky:{bg:"#0D8FDB",fg:"#FFFFFF"},vine:{bg:"#39DBAC",fg:"#1E292C"},lava:{bg:"#F8591A",fg:"#1C2846"}}},defaults:{size:10,units:"pt",scale:1/16}},F=(g=d=h=null,function(e){e=e.root;if(k.setup.supportsSVG){var t=!1;null!=h&&h.parentNode===document.body||(t=!0),(h=v.initSVG(h,e.properties.width,e.properties.height)).style.display="block",t&&(d=y.newEl("text",E),g=document.createTextNode(null),y.setAttr(d,{x:0}),d.appendChild(g),h.appendChild(d),document.body.appendChild(h),h.style.visibility="hidden",h.style.position="absolute",h.style.top="-100%",h.style.left="-100%");var t=e.children.holderTextGroup.properties,n=(y.setAttr(d,{y:t.font.size,style:m.cssProps({"font-weight":t.font.weight,"font-size":t.font.size+t.font.units,"font-family":t.font.family})}),y.newEl("textarea")),n=(n.innerHTML=t.text,g.nodeValue=n.value,d.getBBox()),e=Math.ceil(n.width/e.properties.width),r=t.text.split(" "),i=t.text.match(/\\n/g),i=(e+=null==i?0:i.length,g.nodeValue=t.text.replace(/[ ]+/g,""),d.getComputedTextLength()),t=n.width-i,i=Math.round(t/Math.max(1,r.length-1)),o=[];if(1<e){g.nodeValue="";for(var a,s=0;s<r.length;s++)0!==r[s].length&&(g.nodeValue=m.decodeHtmlEntity(r[s]),a=d.getBBox(),o.push({text:r[s],width:a.width}))}return h.style.display="none",{spaceWidth:i,lineCount:e,boundingBox:n,words:o}}return!1});for(n in k.flags)k.flags.hasOwnProperty(n)&&(k.flags[n].match=function(e){return e.match(this.regex)});k.setup={renderer:"html",debounce:100,ratio:1,supportsCanvas:!1,supportsSVG:!1,lineWrapRatio:.9,dataAttr:"data-src",renderers:["html","canvas","svg"]},k.vars={preempted:!1,resizableImages:[],invisibleImages:{},invisibleId:0,visibilityCheckStarted:!1,debounceTimer:null,cache:{}},(s=y.newEl("canvas")).getContext&&-1!=s.toDataURL("image/png").indexOf("data:image/png")&&(k.setup.renderer="canvas",k.setup.supportsCanvas=!0),document.createElementNS&&document.createElementNS(E,"svg").createSVGRect&&(k.setup.renderer="svg",k.setup.supportsSVG=!0),k.vars.visibilityCheckStarted||(l.requestAnimationFrame(e),k.vars.visibilityCheckStarted=!0),r&&r(function(){k.vars.preempted||T.run(),l.addEventListener?(l.addEventListener("resize",t,!1),l.addEventListener("orientationchange",t,!1)):l.attachEvent("onresize",t),"object"==typeof l.Turbolinks&&l.document.addEventListener("page:change",function(){T.run()})}),j.exports=T}.call(e,function(){return this}())},function(e,t){e.exports="undefined"!=typeof window&&function(e){function n(e){if(!x){if(!a.body)return i(n);for(x=!0;e=S.shift();)i(e)}}function t(e){!w&&e.type!==l&&a[u]!==c||(r(),n())}function r(){w?(a[y](m,t,h),e[y](l,t,h)):(a[p](v,t),e[p](d,t))}function i(e,t){setTimeout(e,0<=+t?t:1)}function o(e){x?i(e):S.push(e)}null==document.readyState&&document.addEventListener&&(document.addEventListener("DOMContentLoaded",function e(){document.removeEventListener("DOMContentLoaded",e,!1),document.readyState="complete"},!1),document.readyState="loading");var a=e.document,s=a.documentElement,l="load",h=!1,d="on"+l,c="complete",u="readyState",f="attachEvent",p="detachEvent",g="addEventListener",m="DOMContentLoaded",v="onreadystatechange",y="removeEventListener",w=g in a,b=h,x=h,S=[];if(a[u]===c)i(n);else if(w)a[g](m,t,h),e[g](l,t,h);else{a[f](v,t),e[f](d,t);try{b=null==e.frameElement&&s}catch(e){}b&&b.doScroll&&!function t(){if(!x){try{b.doScroll("left")}catch(e){return i(t,50)}r(),n()}}()}return o.version="1.4.0",o.isReady=function(){return x},o}(window)},function(e,t,n){var o=encodeURIComponent,h=decodeURIComponent,d=n(4),a=n(5),c=/(\w+)\[(\d+)\]/,u=/\w+\.\w+/;t.parse=function(e){if("string"!=typeof e)return{};if(""===(e=d(e)))return{};for(var t={},n=(e="?"===e.charAt(0)?e.slice(1):e).split("&"),r=0;r<n.length;r++){var i,o,a,s=n[r].split("="),l=h(s[0]);if(i=c.exec(l))t[i[1]]=t[i[1]]||[],t[i[1]][i[2]]=h(s[1]);else if(i=u.test(l)){for(i=l.split("."),o=t;i.length;)if((a=i.shift()).length){if(o[a]){if(o[a]&&"object"!=typeof o[a])break}else o[a]={};i.length||(o[a]=h(s[1])),o=o[a]}}else t[s[0]]=null==s[1]?"":h(s[1])}return t},t.stringify=function(e){if(!e)return"";var t,n=[];for(t in e){var r=e[t];if("array"!=a(r))n.push(o(t)+"="+o(e[t]));else for(var i=0;i<r.length;++i)n.push(o(t+"["+i+"]")+"="+o(r[i]))}return n.join("&")}},function(e,t){(t=e.exports=function(e){return e.replace(/^\s*|\s*$/g,"")}).left=function(e){return e.replace(/^\s*/,"")},t.right=function(e){return e.replace(/\s*$/,"")}},function(e,t){var n=Object.prototype.toString;e.exports=function(e){switch(n.call(e)){case"[object Date]":return"date";case"[object RegExp]":return"regexp";case"[object Arguments]":return"arguments";case"[object Array]":return"array";case"[object Error]":return"error"}return null===e?"null":void 0===e?"undefined":e!=e?"nan":e&&1===e.nodeType?"element":null!=(t=e)&&(t._isBuffer||t.constructor&&"function"==typeof t.constructor.isBuffer&&t.constructor.isBuffer(t))?"buffer":typeof(e=e.valueOf?e.valueOf():Object.prototype.valueOf.apply(e));var t}},function(e,t){e.exports=function(e){function o(e){s++,this.parent=null,this.children={},this.id=s,this.name="n"+s,void 0!==e&&(this.name=e),this.x=this.y=this.z=0,this.width=this.height=0}function t(){o.call(this,"root"),this.properties=e}function n(e,t){if(o.call(this,e),this.properties={fill:"#000000"},void 0!==t){var n,r=this.properties,i=t;for(n in i)r[n]=i[n]}else if(void 0!==e&&"string"!=typeof e)throw"SceneGraph: invalid node name"}function r(){n.apply(this,arguments),this.type="group"}function i(){n.apply(this,arguments),this.type="rect"}function a(e){n.call(this),this.type="text",this.properties.text=e}var s=1,l=(o.prototype.resize=function(e,t){null!=e&&(this.width=e),null!=t&&(this.height=t)},o.prototype.moveTo=function(e,t,n){this.x=null!=e?e:this.x,this.y=null!=t?t:this.y,this.z=null!=n?n:this.z},o.prototype.add=function(e){var t=e.name;if(void 0!==this.children[t])throw"SceneGraph: child already exists: "+t;(this.children[t]=e).parent=this},t.prototype=new o,n.prototype=new o,r.prototype=new n,i.prototype=new n,a.prototype=new n,new t);return this.Shape={Rect:i,Text:a,Group:r},this.root=l,this}},function(e,t){!function(r){t.extend=function(e,t){var n,r={};for(n in e)e.hasOwnProperty(n)&&(r[n]=e[n]);if(null!=t)for(var i in t)t.hasOwnProperty(i)&&(r[i]=t[i]);return r},t.cssProps=function(e){var t,n=[];for(t in e)e.hasOwnProperty(t)&&n.push(t+":"+e[t]);return n.join(";")},t.encodeHtmlEntity=function(e){for(var t=[],n=0,r=e.length-1;0<=r;r--)n=e.charCodeAt(r),t.unshift(128<n?["&#",n,";"].join(""):e[r]);return t.join("")},t.imageExists=function(e,t){var n=new Image;n.onerror=function(){t.call(this,!1)},n.onload=function(){t.call(this,!0)},n.src=e},t.decodeHtmlEntity=function(e){return e.replace(/&#(\d+);/g,function(e,t){return String.fromCharCode(t)})},t.dimensionCheck=function(e){e={height:e.clientHeight,width:e.clientWidth};return!(!e.height||!e.width)&&e},t.truthy=function(e){return"string"==typeof e?"true"===e||"yes"===e||"1"===e||"on"===e||"✓"===e:!!e},t.parseColor=function(e){var t,n=e.match(/(^(?:#?)[0-9a-f]{6}$)|(^(?:#?)[0-9a-f]{3}$)/i);return null!==n?"#"!==(t=n[1]||n[2])[0]?"#"+t:t:null!==(n=e.match(/^rgb\((\d{1,3})\s*,\s*(\d{1,3})\s*,\s*(\d{1,3})\s*\)$/))?"rgb("+n.slice(1).join(",")+")":null!==(n=e.match(/^rgba\((\d{1,3})\s*,\s*(\d{1,3})\s*,\s*(\d{1,3})\s*,\s*(0\.\d{1,}|1)\)$/))?"rgba("+n.slice(1).join(",")+")":null},t.canvasRatio=function(){var e,t=1,n=1;return r.document&&(e=r.document.createElement("canvas")).getContext&&(e=e.getContext("2d"),t=r.devicePixelRatio||1,n=e.webkitBackingStorePixelRatio||e.mozBackingStorePixelRatio||e.msBackingStorePixelRatio||e.oBackingStorePixelRatio||e.backingStorePixelRatio||1),t/n}}.call(t,function(){return this}())},function(e,t,n){!function(l){var h=n(9),a="http://www.w3.org/2000/svg";t.initSVG=function(e,t,n){var r,i=!1;e&&e.querySelector?null===(r=e.querySelector("style"))&&(i=!0):(e=h.newEl("svg",a),i=!0),i&&(i=h.newEl("defs",a),r=h.newEl("style",a),h.setAttr(r,{type:"text/css"}),i.appendChild(r),e.appendChild(i)),e.webkitMatchesSelector&&e.setAttribute("xmlns",a);for(var o=0;o<e.childNodes.length;o++)8===e.childNodes[o].nodeType&&e.removeChild(e.childNodes[o]);for(;r.childNodes.length;)r.removeChild(r.childNodes[0]);return h.setAttr(e,{width:t,height:n,viewBox:"0 0 "+t+" "+n,preserveAspectRatio:"none"}),e},t.svgStringToDataURI=function(e,t){return t?"data:image/svg+xml;charset=UTF-8;base64,"+btoa(l.unescape(encodeURIComponent(e))):"data:image/svg+xml;charset=UTF-8,"+encodeURIComponent(e)},t.serializeSVG=function(e,t){if(l.XMLSerializer){var n=new XMLSerializer,r="",i=t.stylesheets;if(t.svgXMLStylesheet){for(var o=h.createXML(),a=i.length-1;0<=a;a--){var s=o.createProcessingInstruction("xml-stylesheet",'href="'+i[a]+'" rel="stylesheet"');o.insertBefore(s,o.firstChild)}o.removeChild(o.documentElement),r=n.serializeToString(o)}return r+n.serializeToString(e).replace(/\&amp;(\#[0-9]{2,}\;)/g,"&$1")}}}.call(t,function(){return this}())},function(e,t){!function(n){t.newEl=function(e,t){if(n.document)return null==t?n.document.createElement(e):n.document.createElementNS(t,e)},t.setAttr=function(e,t){for(var n in t)e.setAttribute(n,t[n])},t.createXML=function(){if(n.DOMParser)return(new DOMParser).parseFromString("<xml />","application/xml")},t.getNodeArray=function(e){var t=null;return"string"==typeof e?t=document.querySelectorAll(e):n.NodeList&&e instanceof n.NodeList?t=e:n.Node&&e instanceof n.Node?t=[e]:n.HTMLCollection&&e instanceof n.HTMLCollection||e instanceof Array?t=e:null===e&&(t=[]),Array.prototype.slice.call(t)}}.call(t,function(){return this}())},function(e,t){function r(e,t){"string"==typeof e&&("#"===(this.original=e).charAt(0)&&(e=e.slice(1)),/[^a-f0-9]+/i.test(e)||6===(e=3===e.length?e.replace(/./g,"$&$&"):e).length&&(this.alpha=1,t&&t.alpha&&(this.alpha=t.alpha),this.set(parseInt(e,16))))}r.rgb2hex=function(e,t,n){return[e,t,n].map(function(e){var t=(0|e).toString(16);return t=e<16?"0"+t:t}).join("")},r.hsl2rgb=function(e,t,n){var e=e/60,t=(1-Math.abs(2*n-1))*t,r=t*(1-Math.abs(parseInt(e)%2-1)),n=n-t/2,i=0,o=0,a=0;return 0<=e&&e<1?(i=t,o=r):1<=e&&e<2?(i=r,o=t):2<=e&&e<3?(o=t,a=r):3<=e&&e<4?(o=r,a=t):4<=e&&e<5?(i=r,a=t):5<=e&&e<6&&(i=t,a=r),i+=n,o+=n,a+=n,[i=parseInt(255*i),o=parseInt(255*o),a=parseInt(255*a)]},r.prototype.set=function(e){this.raw=e;var e=(16711680&this.raw)>>16,t=(65280&this.raw)>>8,n=255&this.raw,r=.2126*e+.7152*t+.0722*n,i=-.09991*e-.33609*t+.436*n,o=.615*e-.55861*t-.05639*n;return this.rgb={r:e,g:t,b:n},this.yuv={y:r,u:i,v:o},this},r.prototype.lighten=function(e){var e=255*(Math.min(1,Math.max(0,Math.abs(e)))*(e<0?-1:1))|0,t=Math.min(255,Math.max(0,this.rgb.r+e)),n=Math.min(255,Math.max(0,this.rgb.g+e)),e=Math.min(255,Math.max(0,this.rgb.b+e)),t=r.rgb2hex(t,n,e);return new r(t)},r.prototype.toHex=function(e){return(e?"#":"")+this.raw.toString(16)},r.prototype.lighterThan=function(e){return e instanceof r||(e=new r(e)),this.yuv.y>e.yuv.y},r.prototype.blendAlpha=function(e){var e=e=e instanceof r?e:new r(e),t=e.alpha*e.rgb.r+(1-e.alpha)*this.rgb.r,n=e.alpha*e.rgb.g+(1-e.alpha)*this.rgb.g,e=e.alpha*e.rgb.b+(1-e.alpha)*this.rgb.b;return new r(r.rgb2hex(t,n,e))},e.exports=r},function(e,t){e.exports={version:"2.9.6",svg_ns:"http://www.w3.org/2000/svg"}},function(e,t,n){var f=n(13),p=n(8),r=n(11),g=n(7),m=r.svg_ns,v=function(e){var t=e.tag,n=e.content||"";return delete e.tag,delete e.content,[t,n,e]};e.exports=function(e,t){var n,r=t.engineSettings.stylesheets.map(function(e){return'<?xml-stylesheet rel="stylesheet" href="'+e+'"?>'}).join("\n"),i="holder_"+Number(new Date).toString(16),e=e.root,o=e.children.holderTextGroup,a="#"+i+" text { "+(a=o.properties,g.cssProps({fill:a.fill,"font-weight":a.font.weight,"font-family":a.font.family+", monospace","font-size":a.font.size+a.font.units}))+" } ",s=(o.y+=.8*o.textPositionData.boundingBox.height,[]),l=(Object.keys(o.children).forEach(function(e){var r=o.children[e];Object.keys(r.children).forEach(function(e){var e=r.children[e],t=o.x+r.x+e.x,n=o.y+r.y+e.y,e=v({tag:"text",content:e.properties.text,x:t,y:n});s.push(e)})}),v({tag:"g",content:s})),h=null,d=(e.children.holderBg.properties.outline&&(u=e.children.holderBg.properties.outline,h=v({tag:"path",d:(d=e.children.holderBg.width,n=e.children.holderBg.height,c=u.width,["M",c/=2,c,"H",d-c,"V",n-c,"H",c,"V",0,"M",0,c,"L",d,n-c,"M",0,n-c,"L",d,c].join(" ")),"stroke-width":u.width,stroke:u.fill,fill:"none"})),n=e.children.holderBg,v({tag:"rect",width:n.width,height:n.height,fill:n.properties.fill})),c=[],u=(c.push(d),u&&c.push(h),c.push(l),v({tag:"g",id:i,content:c})),h=v({tag:"style",content:a,type:"text/css"}),l=v({tag:"defs",content:h}),i=v({tag:"svg",content:[l,u],width:e.properties.width,height:e.properties.height,xmlns:m,viewBox:[0,0,e.properties.width,e.properties.height].join(" "),preserveAspectRatio:"none"}),a=f(i);return/\&amp;(x)?#[0-9A-Fa-f]/.test(a[0])&&(a[0]=a[0].replace(/&amp;#/gm,"&#")),a=r+a[0],p.svgStringToDataURI(a,"background"===t.mode)}},function(e,t,n){n(14),e.exports=function e(t,n,r){"use strict";function i(e,t){if(null!==t&&!1!==t&&void 0!==t)return"string"!=typeof t&&"object"!=typeof t?String(t):t}var o,a,s,l,h,d,c,u,f,p,g,m=1,v=!0;if(r=r||{},"string"==typeof t[0])t[0]=(h=t[0],d={tag:(d=h.match(/^[\w-]+/))?d[0]:"div",attr:{},children:[]},c=h.match(/#([\w-]+)/),u=h.match(/\$([\w-]+)/),f=h.match(/\.[\w-]+/g),c&&(d.attr.id=c[1],r[c[1]]=d),u&&(r[u[1]]=d),f&&(d.attr.class=f.join(" ").replace(/\./g,"")),h.match(/&$/g)&&(v=!1),d);else{if(!Array.isArray(t[0]))throw new Error("First element of array must be a string, or an array and not "+JSON.stringify(t[0]));m=0}for(;m<t.length;m++){if(!1===t[m]||null===t[m]){t[0]=!1;break}if(void 0!==t[m]&&!0!==t[m])if("string"==typeof t[m])v&&(t[m]=(p=t[m],String(p).replace(/&/g,"&amp;").replace(/"/g,"&quot;").replace(/'/g,"&apos;").replace(/</g,"&lt;").replace(/>/g,"&gt;"))),t[0].children.push(t[m]);else if("number"==typeof t[m])t[0].children.push(t[m]);else if(Array.isArray(t[m])){if(Array.isArray(t[m][0])){if(t[m].reverse().forEach(function(e){t.splice(m+1,0,e)}),0!==m)continue;m++}e(t[m],n,r),t[m][0]&&t[0].children.push(t[m][0])}else if("function"==typeof t[m])s=t[m];else{if("object"!=typeof t[m])throw new TypeError('"'+t[m]+'" is not allowed as a value.');for(a in t[m])t[m].hasOwnProperty(a)&&null!==t[m][a]&&!1!==t[m][a]&&("style"===a&&"object"==typeof t[m][a]?t[0].attr[a]=JSON.stringify(t[m][a],i).slice(2,-2).replace(/","/g,";").replace(/":"/g,":").replace(/\\"/g,"'"):t[0].attr[a]=t[m][a])}}if(!1!==t[0]){for(l in o="<"+t[0].tag,t[0].attr)t[0].attr.hasOwnProperty(l)&&(o+=" "+l+'="'+(g=t[0].attr[l],g||0===g?String(g).replace(/&/g,"&amp;").replace(/"/g,"&quot;"):"")+'"');o+=">",t[0].children.forEach(function(e){o+=e}),o+="</"+t[0].tag+">",t[0]=o}return r[0]=t[0],s&&s(t[0]),r}},function(e,t){"use strict";var a=/["'&<>]/;e.exports=function(e){var t=""+e;if(!(e=a.exec(t)))return t;for(var n,r="",i=0,o=0,i=e.index;i<t.length;i++){switch(t.charCodeAt(i)){case 34:n="&quot;";break;case 38:n="&amp;";break;case 39:n="&#39;";break;case 60:n="&lt;";break;case 62:n="&gt;";break;default:continue}o!==i&&(r+=t.substring(o,i)),o=i+1,r+=n}return o!==i?r+t.substring(o,i):r}},function(e,t,n){var u,f,r=n(9),p=n(7);e.exports=(u=r.newEl("canvas"),f=null,function(e){null==f&&(f=u.getContext("2d"));var t,n=p.canvasRatio(),e=e.root,r=(u.width=n*e.properties.width,u.height=n*e.properties.height,f.textBaseline="middle",e.children.holderBg),i=n*r.width,o=n*r.height,a=(f.fillStyle=r.properties.fill,f.fillRect(0,0,i,o),r.properties.outline&&(f.strokeStyle=r.properties.outline.fill,f.lineWidth=r.properties.outline.width,f.moveTo(1,1),f.lineTo(i-1,1),f.lineTo(i-1,o-1),f.lineTo(1,o-1),f.lineTo(1,1),f.moveTo(0,1),f.lineTo(i,o-1),f.moveTo(0,o-1),f.lineTo(i,1),f.stroke()),e.children.holderTextGroup);for(t in f.font=a.properties.font.weight+" "+n*a.properties.font.size+a.properties.font.units+" "+a.properties.font.family+", monospace",f.fillStyle=a.properties.fill,a.children){var s,l=a.children[t];for(s in l.children){var h=l.children[s],d=n*(a.x+l.x+h.x),c=n*(a.y+l.y+h.y+a.properties.leading/2);f.fillText(h.properties.text,d,c)}}return u.toDataURL("image/png")})}],i={},n.m=r,n.c=i,n.p="",n(0);function n(e){var t;return(i[e]||(t=i[e]={exports:{},id:e,loaded:!1},r[e].call(t.exports,t,t.exports,n),t.loaded=!0,t)).exports}var r,i}),function(e){"undefined"!=typeof Meteor&&"undefined"!=typeof Package&&(Holder=e.Holder)}(this);