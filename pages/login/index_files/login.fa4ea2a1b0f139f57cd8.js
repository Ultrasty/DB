(window.webpackJsonp = window.webpackJsonp || []).push([
    [11], {
        261: function (e, t, n) {
            "use strict";
            n(16), n(76);
            var r = "undefined" != typeof Reflect ? Reflect.construct : void 0,
                i = Object.defineProperty,
                a = Error.captureStackTrace;

            function c(e) {
                void 0 !== e && i(this, "message", {
                    configurable: !0,
                    value: e,
                    writable: !0
                });
                var t = this.constructor.name;
                void 0 !== t && t !== this.name && i(this, "name", {
                    configurable: !0,
                    value: t,
                    writable: !0
                }), a(this, this.constructor)
            }
            void 0 === a && (a = function (e) {
                var t = new Error;
                i(e, "stack", {
                    configurable: !0,
                    get: function () {
                        var e = t.stack;
                        return i(this, "stack", {
                            configurable: !0,
                            value: e,
                            writable: !0
                        }), e
                    },
                    set: function (t) {
                        i(e, "stack", {
                            configurable: !0,
                            value: t,
                            writable: !0
                        })
                    }
                })
            }), c.prototype = Object.create(Error.prototype, {
                constructor: {
                    configurable: !0,
                    value: c,
                    writable: !0
                }
            });
            var o = function () {
                function e(e, t) {
                    return i(e, "name", {
                        configurable: !0,
                        value: t
                    })
                }
                try {
                    var t = function () {};
                    if (e(t, "foo"), "foo" === t.name) return e
                } catch (e) {}
            }();
            (e.exports = function (e, t) {
                if (null == t || t === Error) t = c;
                else if ("function" != typeof t) throw new TypeError("super_ should be a function");
                var n;
                if ("string" == typeof e) n = e, e = void 0 !== r ? function () {
                    return r(t, arguments, this.constructor)
                } : function () {
                    t.apply(this, arguments)
                }, void 0 !== o && (o(e, n), n = void 0);
                else if ("function" != typeof e) throw new TypeError("constructor should be either a string or a function");
                e.super_ = e.super = t;
                var i = {
                    constructor: {
                        configurable: !0,
                        value: e,
                        writable: !0
                    }
                };
                return void 0 !== n && (i.name = {
                    configurable: !0,
                    value: n,
                    writable: !0
                }), e.prototype = Object.create(t.prototype, i), e
            }).BaseError = c
        },
        344: function (e, t, n) {
            "use strict";
            n.r(t);
            var r = n(6),
                i = n.n(r),
                a = (n(48), n(10)),
                c = n(0),
                o = n(78),
                s = n(47),
                u = n.n(s),
                p = n(4),
                l = n(1),
                d = n.n(l),
                h = n(55),
                f = n.n(h),
                v = (n(14), n(49), n(20), n(53), n(65), n(19), n(9), n(42), n(76), n(18), n(100), n(29), n(89)),
                b = n(24),
                w = n(2),
                y = n(22),
                g = n(27),
                x = n(7),
                j = n(34),
                m = n(31),
                O = n(17),
                k = n(77),
                C = n.n(k),
                A = (n(70), n(91)),
                R = n(92),
                S = (n(46), n(16), n(261));

            function V(e) {
                var t = function () {
                    if ("undefined" == typeof Reflect || !Reflect.construct) return !1;
                    if (Reflect.construct.sham) return !1;
                    if ("function" == typeof Proxy) return !0;
                    try {
                        return Date.prototype.toString.call(Reflect.construct(Date, [], (function () {}))), !0
                    } catch (e) {
                        return !1
                    }
                }();
                return function () {
                    var n, r = Object(O.a)(e);
                    if (t) {
                        var i = Object(O.a)(this).constructor;
                        n = Reflect.construct(r, arguments, i)
                    } else n = r.apply(this, arguments);
                    return Object(m.a)(this, n)
                }
            }
            var _ = function (e) {
                    Object(j.a)(n, e);
                    var t = V(n);

                    function n(e, r) {
                        var i;
                        return Object(y.a)(this, n), (i = t.call(this, "".concat(e.status, " ").concat(e.statusText).concat(r ? " ".concat(r) : ""))).name = "LoginError", i
                    }
                    return n
                }(n.n(S).a.BaseError),
                E = n(66),
                P = n(131),
                I = n(71),
                T = n(1008),
                D = n(5);

            function K() {
                return Object(c.jsx)(L, {
                    role: "progressbar",
                    children: Object(c.jsx)(q, {
                        role: "progressbar"
                    })
                })
            }
            var L = D.d.div.withConfig({
                    componentId: "sc-13ewc65-0"
                })(["margin:auto;padding:16px;border-radius:8px;font-size:48px;width:48px;height:48px;background-color:rgba(255,255,255,0.68);color:rgba(0,0,0,0.16);backdrop-filter:blur(32px);"]),
                U = Object(D.e)(["from{transform:scale(0);opacity:1;}to{transform:scale(1);opacity:0;}"]),
                q = D.d.div.withConfig({
                    componentId: "sc-13ewc65-1"
                })(["width:1em;height:1em;border-radius:1em;background-color:currentColor;animation:", " 1s infinite ease-out;"], U);

            function N(e, t) {
                var n = Object.keys(e);
                if (Object.getOwnPropertySymbols) {
                    var r = Object.getOwnPropertySymbols(e);
                    t && (r = r.filter((function (t) {
                        return Object.getOwnPropertyDescriptor(e, t).enumerable
                    }))), n.push.apply(n, r)
                }
                return n
            }

            function B(e) {
                for (var t = 1; t < arguments.length; t++) {
                    var n = null != arguments[t] ? arguments[t] : {};
                    t % 2 ? N(Object(n), !0).forEach((function (t) {
                        Object(b.a)(e, t, n[t])
                    })) : Object.getOwnPropertyDescriptors ? Object.defineProperties(e, Object.getOwnPropertyDescriptors(n)) : N(Object(n)).forEach((function (t) {
                        Object.defineProperty(e, t, Object.getOwnPropertyDescriptor(n, t))
                    }))
                }
                return e
            }

            function F(e) {
                var t = function () {
                    if ("undefined" == typeof Reflect || !Reflect.construct) return !1;
                    if (Reflect.construct.sham) return !1;
                    if ("function" == typeof Proxy) return !0;
                    try {
                        return Date.prototype.toString.call(Reflect.construct(Date, [], (function () {}))), !0
                    } catch (e) {
                        return !1
                    }
                }();
                return function () {
                    var n, r = Object(O.a)(e);
                    if (t) {
                        var i = Object(O.a)(this).constructor;
                        n = Reflect.construct(r, arguments, i)
                    } else n = r.apply(this, arguments);
                    return Object(m.a)(this, n)
                }
            }
            var W = function (e) {
                Object(j.a)(r, e);
                var t, n = F(r);

                function r(e) {
                    var t;
                    return Object(y.a)(this, r), (t = n.call(this, e)).state = {
                        requestSending: !1,
                        inputValues: {
                            pixiv_id: pixivLogin.pixivId || "",
                            captcha: "",
                            g_recaptcha_response: ""
                        },
                        errors: pixivLogin.pixivIdError ? {
                            pixiv_id: pixivLogin.pixivIdError
                        } : {},
                        failedCount: 0
                    }, t.pixivIdRef = null, t.passwordRef = null, t.savePixivIdRef = t.savePixivIdRef.bind(Object(x.a)(t)), t.savePasswordRef = t.savePasswordRef.bind(Object(x.a)(t)), t.handleFormSubmit = t.handleFormSubmit.bind(Object(x.a)(t)), t.handlePixivIdChange = t.handlePixivIdChange.bind(Object(x.a)(t)), t.handleKeyDown = t.handleKeyDown.bind(Object(x.a)(t)), t.handleClickReminderLink = t.handleClickReminderLink.bind(Object(x.a)(t)), t.handleVerify = t.handleVerify.bind(Object(x.a)(t)), t
                }
                return Object(g.a)(r, [{
                    key: "componentDidMount",
                    value: function () {
                        document.getElementById("old-login").style.display = "none", Object(I.b)(this.props.recaptchaV3SiteKey)
                    }
                }, {
                    key: "getRecaptchaV3Token",
                    value: (t = Object(a.a)(i.a.mark((function e() {
                        var t, n, r, a;
                        return i.a.wrap((function (e) {
                            for (;;) switch (e.prev = e.next) {
                                case 0:
                                    return n = this.props, r = n.recaptchaV3SiteKey, a = n.recaptchaV3Action, e.next = 3, Object(I.a)(r, a, 15e3);
                                case 3:
                                    if (e.t1 = t = e.sent, e.t0 = null !== e.t1, !e.t0) {
                                        e.next = 7;
                                        break
                                    }
                                    e.t0 = void 0 !== t;
                                case 7:
                                    if (!e.t0) {
                                        e.next = 11;
                                        break
                                    }
                                    e.t2 = t, e.next = 12;
                                    break;
                                case 11:
                                    e.t2 = "";
                                case 12:
                                    return e.abrupt("return", e.t2);
                                case 13:
                                case "end":
                                    return e.stop()
                            }
                        }), e, this)
                    }))), function () {
                        return t.apply(this, arguments)
                    })
                }, {
                    key: "handleFormSubmit",
                    value: function (e) {
                        var t = this;
                        e.preventDefault(), this.state.requestSending || this.setState(function (e) {
                            return Object(w.a)(this, t), {
                                inputValues: B(B({}, e.inputValues), {}, {
                                    pixiv_id: this.pixivIdRef.value,
                                    password: this.passwordRef.value
                                }),
                                requestSending: !0
                            }
                        }.bind(this), Object(a.a)(i.a.mark((function e() {
                            var n, r, a, c, o, s, u, l, d, h, f, b, y = this;
                            return i.a.wrap((function (e) {
                                for (;;) switch (e.prev = e.next) {
                                    case 0:
                                        return n = t.state.inputValues, r = n.pixiv_id, a = Object(v.a)(n, ["pixiv_id"]), c = B(B({}, a), {}, {
                                            pixiv_id: r.trim()
                                        }), e.next = 4, t.getRecaptchaV3Token();
                                    case 4:
                                        return o = e.sent, s = B(B({}, c), {}, {
                                            post_key: t.props.postKey,
                                            source: t.props.source,
                                            ref: t.props.refer,
                                            return_to: t.props.returnTo,
                                            recaptcha_v3_token: o
                                        }), e.prev = 6, e.next = 9, fetch("/api/login?lang=".concat(encodeURIComponent(t.props.lang)), {
                                            method: "POST",
                                            body: C.a.stringify(s),
                                            headers: {
                                                Accept: "application/json",
                                                "Content-Type": "application/x-www-form-urlencoded"
                                            },
                                            credentials: "same-origin",
                                            cache: "no-cache"
                                        });
                                    case 9:
                                        if ((u = e.sent).ok) {
                                            e.next = 12;
                                            break
                                        }
                                        throw u;
                                    case 12:
                                        return e.next = 14, u.json();
                                    case 14:
                                        if (!(l = e.sent).error) {
                                            e.next = 18;
                                            break
                                        }
                                        return alert(l.message), e.abrupt("return");
                                    case 18:
                                        void 0 === (d = l.body.validation_errors) || 0 === !Object.keys(d).length ? window.ga("send", {
                                            hitType: "event",
                                            eventCategory: t.props.gaEventCategory,
                                            eventAction: "success",
                                            eventValue: t.state.failedCount,
                                            hitCallback: Object(E.a)(function () {
                                                Object(w.a)(this, y), Object(T.a)(l.body.success.return_to, l.body.success.return_to_method)
                                            }.bind(this))
                                        }) : (t.setState(function (e) {
                                            return Object(w.a)(this, y), {
                                                requestSending: !1,
                                                errors: d,
                                                inputValues: B(B({}, e.inputValues), {}, {
                                                    captcha: ""
                                                }),
                                                failedCount: e.failedCount + 1
                                            }
                                        }.bind(this)), window.ga("send", {
                                            hitType: "event",
                                            eventCategory: t.props.gaEventCategory,
                                            eventAction: "failed",
                                            eventValue: t.state.failedCount
                                        })), e.next = 48;
                                        break;
                                    case 22:
                                        if (e.prev = 22, e.t0 = e.catch(6), !(e.t0 instanceof Response)) {
                                            e.next = 47;
                                            break
                                        }
                                        if (h = function (e) {
                                                var n = this;
                                                Object(w.a)(this, y), t.setState(function (t) {
                                                    return Object(w.a)(this, n), {
                                                        errors: {
                                                            etc: [e]
                                                        },
                                                        inputValues: B(B({}, t.inputValues), {}, {
                                                            captcha: ""
                                                        }),
                                                        requestSending: !1
                                                    }
                                                }.bind(this))
                                            }.bind(this), !(e.t0.status >= 500)) {
                                            e.next = 29;
                                            break
                                        }
                                        throw h(t.props.t(p.c.common.error.serverError)), new _(e.t0);
                                    case 29:
                                        return e.prev = 29, e.next = 32, e.t0.json();
                                    case 32:
                                        if (f = e.sent, !(b = f.message)) {
                                            e.next = 37;
                                            break
                                        }
                                        throw h(b), new _(e.t0, b);
                                    case 37:
                                        e.next = 43;
                                        break;
                                    case 39:
                                        if (e.prev = 39, e.t1 = e.catch(29), "string" != typeof e.t1) {
                                            e.next = 43;
                                            break
                                        }
                                        throw e.t1;
                                    case 43:
                                        throw h(t.props.t(p.c.common.error.exceptionalError)), new _(e.t0, "exceptional error");
                                    case 47:
                                        throw e.t0;
                                    case 48:
                                        return e.prev = 48, t.setState({
                                            requestSending: !1
                                        }), "require_refresh" === t.state.errors.code && (t.setState({
                                            requestSending: !0
                                        }), window.setTimeout(function () {
                                            Object(w.a)(this, y), location.reload()
                                        }.bind(this), 2500)), e.finish(48);
                                    case 52:
                                    case "end":
                                        return e.stop()
                                }
                            }), e, this, [
                                [6, 22, 48, 52],
                                [29, 39]
                            ])
                        }))))
                    }
                }, {
                    key: "handlePixivIdChange",
                    value: function () {
                        var e = this;
                        this.setState(function (t) {
                            return Object(w.a)(this, e), {
                                inputValues: B(B({}, t.inputValues), {}, {
                                    pixiv_id: this.pixivIdRef.value.trim()
                                })
                            }
                        }.bind(this))
                    }
                }, {
                    key: "handleKeyDown",
                    value: function (e) {
                        " " === e.key && e.preventDefault()
                    }
                }, {
                    key: "handleVerify",
                    value: function (e) {
                        var t = this;
                        this.setState(function (n) {
                            return Object(w.a)(this, t), {
                                inputValues: B(B({}, n.inputValues), {}, {
                                    g_recaptcha_response: e
                                })
                            }
                        }.bind(this))
                    }
                }, {
                    key: "handleClickReminderLink",
                    value: function (e) {
                        var t = this;
                        e.preventDefault(), window.ga("send", {
                            hitType: "event",
                            eventCategory: this.props.gaEventCategory,
                            eventAction: "click-reminder-link",
                            eventValue: this.state.failedCount,
                            hitCallback: Object(E.a)(function () {
                                Object(w.a)(this, t), location.href = this.props.reminderUrl
                            }.bind(this))
                        })
                    }
                }, {
                    key: "savePixivIdRef",
                    value: function (e) {
                        this.pixivIdRef = e
                    }
                }, {
                    key: "savePasswordRef",
                    value: function (e) {
                        this.passwordRef = e
                    }
                }, {
                    key: "renderCaptcha",
                    value: function () {
                        switch (this.props.captchaType) {
                            case "ReCaptcha":
                                return Object(c.jsx)(R.a, {
                                    id: "g-recaptcha",
                                    onVerify: this.handleVerify,
                                    recaptchaV2SiteKey: this.props.recaptchaV2SiteKey
                                });
                            default:
                                throw new Error("Invalid captchaType: ".concat(this.props.captchaType))
                        }
                    }
                }, {
                    key: "render",
                    value: function () {
                        return Object(c.jsxs)("div", {
                            id: "LoginComponent",
                            children: [Object(c.jsxs)("form", {
                                onSubmit: this.handleFormSubmit,
                                children: [Object(c.jsxs)("div", {
                                    className: "input-field-group",
                                    children: [Object(c.jsx)("div", {
                                        className: "input-field",
                                        children: Object(c.jsx)("input", {
                                            ref: this.savePixivIdRef,
                                            type: "text",
                                            autoComplete: P.a ? "on" : "username",
                                            placeholder: this.props.t(p.c.login.emailOrPixivId),
                                            autoCapitalize: "off",
                                            value: this.state.inputValues.pixiv_id,
                                            onChange: this.handlePixivIdChange,
                                            onKeyDown: this.handleKeyDown
                                        })
                                    }), Object(c.jsx)("div", {
                                        className: "input-field",
                                        children: Object(c.jsx)("input", {
                                            ref: this.savePasswordRef,
                                            type: "password",
                                            autoComplete: P.a ? "on" : "current-password",
                                            placeholder: this.props.t(p.c.login.password),
                                            autoCapitalize: "off",
                                            defaultValue: ""
                                        })
                                    })]
                                }), !!this.state.errors.captcha && this.renderCaptcha(), Object(c.jsx)(A.a, {
                                    errors: this.state.errors,
                                    fieldNames: ["pixiv_id", "password", "password_ban", "captcha", "etc", "lock"],
                                    reminderUrl: this.props.reminderUrl
                                }), Object(c.jsx)("button", {
                                    type: "submit",
                                    className: "signup-form__submit",
                                    disabled: this.state.requestSending,
                                    children: this.props.t(p.c.login.login)
                                }), Object(c.jsx)("div", {
                                    className: "signup-form-nav",
                                    children: Object(c.jsx)("a", {
                                        href: this.props.reminderUrl,
                                        onClick: this.handleClickReminderLink,
                                        children: this.props.t(p.c.common.action.forgotPassowrd)
                                    })
                                })]
                            }), this.state.requestSending && Object(c.jsx)("div", {
                                className: "busy-container",
                                children: Object(c.jsx)(K, {})
                            })]
                        })
                    }
                }]), r
            }(d.a.Component);
            W.displayName = "Login";
            var z = Object(p.f)()(W),
                M = n(147);

            function J() {
                return (J = Object(a.a)(i.a.mark((function e() {
                    var t;
                    return i.a.wrap((function (e) {
                        for (;;) switch (e.prev = e.next) {
                            case 0:
                                return e.next = 2, u()();
                            case 2:
                                return e.next = 4, Object(p.d)(document.documentElement.lang);
                            case 4:
                                if (t = document.getElementById("container-login")) {
                                    e.next = 7;
                                    break
                                }
                                return e.abrupt("return");
                            case 7:
                                window.pixivAccount.shouldSelectAccount ? f.a.render(Object(c.jsx)(o.a, {
                                    children: Object(c.jsx)(M.a, {
                                        continueWithCurrentAccountMethod: window.pixivAccount.continueWithCurrentAccountMethod,
                                        continueWithCurrentAccountUrl: window.pixivAccount.continueWithCurrentAccountUrl,
                                        currentAccount: window.pixivAccount.currentAccount,
                                        gaEventCategory: window.pixivAccount.gaEventCategory,
                                        useAnotherAccountLabel: window.pixivAccount.useAnotherAccountLabel,
                                        useAnotherAccountUrl: window.pixivAccount.useAnotherAccountUrl
                                    })
                                }), t) : f.a.render(Object(c.jsx)(o.a, {
                                    children: Object(c.jsx)(z, {
                                        captchaType: window.pixivAccount.captchaType,
                                        gaEventCategory: window.pixivAccount.gaEventCategory,
                                        lang: window.pixivAccount.lang,
                                        postKey: window.pixivAccount.postKey,
                                        recaptchaV2SiteKey: window.pixivAccount.recaptchaV2SiteKey,
                                        recaptchaV3Action: window.pixivAccount.recaptchaV3Action,
                                        recaptchaV3SiteKey: window.pixivAccount.recaptchaV3SiteKey,
                                        refer: window.pixivAccount.ref,
                                        reminderUrl: window.pixivAccount.reminderUrl,
                                        returnTo: window.pixivAccount.returnTo,
                                        source: window.pixivAccount.source
                                    })
                                }), t);
                            case 8:
                            case "end":
                                return e.stop()
                        }
                    }), e)
                })))).apply(this, arguments)
            }! function () {
                J.apply(this, arguments)
            }()
        }
    },
    [
        [344, 0, 1]
    ]
]);