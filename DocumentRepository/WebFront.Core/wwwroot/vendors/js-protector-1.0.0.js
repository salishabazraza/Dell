'use strict';

var $p = new function () {
    var _base = this;
    var _msg = {
        "violation-cross-site": "An attempt was made to open a webpage of unauthorized domain.",
        "violation-dom-selector": "An attempt was made to apply unauthorized script.",
        "violation-html": "An attempt was made to apply unauthorized script."
    };
    var _allowedRegexes = [];

    var _sanitizeURL = function (surl) {
        var urlObj = _parseUrlJSON(surl);
        var urlHostname = urlObj.host.trim();
        var isValidUrl = false;

        if (urlHostname == '') {
            isValidUrl = true;
        }
        else if (urlHostname.toUpperCase() == location.host.trim().toUpperCase()) {
            isValidUrl = true;
        }
        else {
            for (var key in _allowedRegexes) {
                var allowedRegex = new RegExp(_allowedRegexes[key]);

                if (allowedRegex.test(urlHostname)) {
                    isValidUrl = true;
                    break;
                }
            }
        }

        if (isValidUrl) {
            return surl;
        }
        else {
            alert(_msg["violation-cross-site"]);

            throw _msg["violation-cross-site"] + surl;
        }
    }

    var _parseUrlJSON = function (url) {
        var a = document.createElement('a');
        a.href = url;
        return {
            source: url,
            protocol: a.protocol.replace(':', ''),
            hostname: a.hostname,
            host: a.host,
            port: a.port,
            query: a.search,
            params: (function () {
                var ret = {},
                    seg = a.search.replace(/^\?/, '').split('&'),
                    len = seg.length, i = 0, s;
                for (; i < len; i++) {
                    if (!seg[i]) { continue; }
                    s = seg[i].split('=');
                    ret[s[0]] = s[1];
                }
                return ret;
            })(),
            file: (a.pathname.match(/\/([^\/?#]+)$/i) || [, ''])[1],
            hash: a.hash.replace('#', ''),
            path: a.pathname.replace(/^([^\/])/, '/$1'),
            relative: (a.href.match(/tps?:\/\/[^\/]+(.+)/) || [, ''])[1],
            segments: a.pathname.replace(/^\//, '').split('/')
        };
    }

    var _sanitizeDomSelector = function (selector) {

        if (selector !== window
            && selector !== document
            && /[\<|\>|\&|\%]/g.test(selector)) {
            alert(_msg["violation-dom-selector"]);

            throw _msg["violation-dom-selector"] + selector;
        }
        else {
            return selector;
        }
    };

    var _sanitizeHtml = function (html) {

        if (/<script/g.test(html)) {
            alert(_msg["violation-html"]);

            throw _msg["violation-html"] + html;
        }

        return html;
    };

    var _init = function () {

        var xhr = new XMLHttpRequest();
        xhr.open('GET', "/request.png", true);
        xhr.onreadystatechange = function () {
            // In local files, status is 0 upon success in Mozilla Firefox
            if (xhr.readyState === XMLHttpRequest.DONE) {
                var status = xhr.status;
                if (status === 0 || (status >= 200 && status < 400)) {
                    // The request has been completed successfully
                    var allowedHosts = xhr.getResponseHeader("Content-Security-Policy").split(" ");

                    for (var key in allowedHosts) {
                        var host = allowedHosts[key];

                        if (/(\'([\w|\W]{1,})\')|(frame-ancestors)|(data:)|(default-src)/.test(host)) {
                            continue;
                        }

                        host = host
                            .replace(/([^a-zA-Z0-9])/g, '\\$1')
                            .replace(/[*]/g, '.*');

                        _allowedRegexes.push(host);
                    }
                } else {
                    // Oh no! There has been an error with the request!
                }
            }
        };
        xhr.send(null);
    };

    _init();

    _base.url = _sanitizeURL;
    _base.dom = _sanitizeDomSelector;
    _base.html = _sanitizeHtml;
};