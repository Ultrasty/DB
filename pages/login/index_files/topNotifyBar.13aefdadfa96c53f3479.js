(window.webpackJsonp=window.webpackJsonp||[]).push([[15],{346:function(e,t,n){"use strict";n.r(t);var c=n(6),r=n.n(c),a=(n(48),n(10)),i=n(0),s=n(78),o=n(4),l=n(1),u=n.n(l),p=n(55),d=n.n(p),y=n(47),f=n.n(y),h=(n(14),n(38),n(9),n(42),n(76),n(18),n(22)),v=n(27),b=n(7),j=n(34),O=n(31),m=n(17),x=n(77),w=n.n(x);n(70);function k(e){var t=function(){if("undefined"==typeof Reflect||!Reflect.construct)return!1;if(Reflect.construct.sham)return!1;if("function"==typeof Proxy)return!0;try{return Date.prototype.toString.call(Reflect.construct(Date,[],(function(){}))),!0}catch(e){return!1}}();return function(){var n,c=Object(m.a)(e);if(t){var r=Object(m.a)(this).constructor;n=Reflect.construct(c,arguments,r)}else n=c.apply(this,arguments);return Object(O.a)(this,n)}}var g=function(e){Object(j.a)(c,e);var t,n=k(c);function c(e){var t;return Object(h.a)(this,c),(t=n.call(this,e)).state={agreed:!1},t.handleClick=t.handleClick.bind(Object(b.a)(t)),t}return Object(v.a)(c,[{key:"handleClick",value:(t=Object(a.a)(r.a.mark((function e(t){var n;return r.a.wrap((function(e){for(;;)switch(e.prev=e.next){case 0:t.preventDefault(),this.setState({agreed:!0}),n=this.props.postKey,fetch("/api/privacy_policy_agree",{method:"POST",body:w.a.stringify({tt:n}),headers:{Accept:"application/json","Content-Type":"application/x-www-form-urlencoded"},credentials:"same-origin",cache:"no-cache"});case 4:case"end":return e.stop()}}),e,this)}))),function(e){return t.apply(this,arguments)})},{key:"render",value:function(){if(this.state.agreed)return null;var e=this.props,t=e.privacyPolicyUrl,n=e.t;return Object(i.jsx)("div",{className:"_privacy-policy-banner",children:Object(i.jsxs)("div",{className:"container",children:[Object(i.jsxs)("div",{className:"content",children:[Object(i.jsx)("span",{className:"text",children:n(o.c.privacyPolicyBanner.description)}),Object(i.jsx)("a",{className:"styled-link",href:t,target:"_blank",rel:"noopener",children:n(o.c.privacyPolicyBanner.details)})]}),Object(i.jsx)("button",{className:"styled-button",onClick:this.handleClick,children:n(o.c.privacyPolicyBanner.ok)})]})})}}]),c}(u.a.Component);g.displayName="PrivacyPolicyBanner";var P=Object(o.f)()(g);function C(){return(C=Object(a.a)(r.a.mark((function e(){var t;return r.a.wrap((function(e){for(;;)switch(e.prev=e.next){case 0:return e.next=2,f()();case 2:return e.next=4,Object(o.d)(document.documentElement.lang);case 4:if(t=document.getElementById("js-privacy-policy-banner")){e.next=7;break}return e.abrupt("return");case 7:d.a.render(Object(i.jsx)(s.a,{children:Object(i.jsx)(P,{postKey:window.pixivAccount.tt,privacyPolicyUrl:window.pixivAccount.privacyPolicyUrl})}),t);case 8:case"end":return e.stop()}}),e)})))).apply(this,arguments)}!function(){C.apply(this,arguments)}()}},[[346,0,1]]]);