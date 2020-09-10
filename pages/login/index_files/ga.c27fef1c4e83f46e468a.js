(window.webpackJsonp = window.webpackJsonp || []).push([
    [5], {
        328: function (t, n, e) {
            "use strict";
            e.r(n);
            e(14), e(38), e(69), e(108), e(33), e(28), e(16), e(9), e(18), e(57), e(41);
            var r = e(6),
                a = e.n(r),
                o = (e(48), e(2)),
                i = e(10),
                c = e(47),
                u = e.n(c),
                f = e(66);

            function l(t, n) {
                var e;
                if ("undefined" == typeof Symbol || null == t[Symbol.iterator]) {
                    if (Array.isArray(t) || (e = function (t, n) {
                            if (!t) return;
                            if ("string" == typeof t) return s(t, n);
                            var e = Object.prototype.toString.call(t).slice(8, -1);
                            "Object" === e && t.constructor && (e = t.constructor.name);
                            if ("Map" === e || "Set" === e) return Array.from(t);
                            if ("Arguments" === e || /^(?:Ui|I)nt(?:8|16|32)(?:Clamped)?Array$/.test(e)) return s(t, n)
                        }(t)) || n && t && "number" == typeof t.length) {
                        e && (t = e);
                        var r = 0,
                            a = function () {};
                        return {
                            s: a,
                            n: function () {
                                return r >= t.length ? {
                                    done: !0
                                } : {
                                    done: !1,
                                    value: t[r++]
                                }
                            },
                            e: function (t) {
                                throw t
                            },
                            f: a
                        }
                    }
                    throw new TypeError("Invalid attempt to iterate non-iterable instance.\nIn order to be iterable, non-array objects must have a [Symbol.iterator]() method.")
                }
                var o, i = !0,
                    c = !1;
                return {
                    s: function () {
                        e = t[Symbol.iterator]()
                    },
                    n: function () {
                        var t = e.next();
                        return i = t.done, t
                    },
                    e: function (t) {
                        c = !0, o = t
                    },
                    f: function () {
                        try {
                            i || null == e.return || e.return()
                        } finally {
                            if (c) throw o
                        }
                    }
                }
            }

            function s(t, n) {
                (null == n || n > t.length) && (n = t.length);
                for (var e = 0, r = new Array(n); e < n; e++) r[e] = t[e];
                return r
            }

            function y() {
                return (y = Object(i.a)(a.a.mark((function t() {
                    var n, e;
                    return a.a.wrap((function (t) {
                        for (;;) switch (t.prev = t.next) {
                            case 0:
                                return t.next = 2, u()();
                            case 2:
                                n = l(document.querySelectorAll(".ga-event"));
                                try {
                                    for (n.s(); !(e = n.n()).done;) e.value.addEventListener("click", p)
                                } catch (t) {
                                    n.e(t)
                                } finally {
                                    n.f()
                                }
                                case 4:
                                case "end":
                                    return t.stop()
                        }
                    }), t)
                })))).apply(this, arguments)
            }

            function p(t) {
                var n = this;
                t.preventDefault();
                var e = t.currentTarget;
                window.ga("send", {
                    hitType: "event",
                    eventCategory: e.dataset.category,
                    eventAction: e.dataset.action,
                    eventLabel: e.dataset.label,
                    hitCallback: Object(f.a)(function () {
                        Object(o.a)(this, n), location.href = e.href
                    }.bind(this))
                })
            }! function () {
                y.apply(this, arguments)
            }()
        }
    },
    [
        [328, 0, 1]
    ]
]);