﻿(function ($) {
    $.fn.display1 = function (data) {
        var c = document.getElementById("canvas1");
        c.width = window.innerWidth;
        c.height = window.innerHeight;
        var ctx = c.getContext("2d");
        var wEdge = 180, hEdge = 90;
        var x, y, r1, r2, r3, r4;
        class range {
            constructor(start, end) {
                this.start = start;
                this.end = end;
            }
        }
        r1 = new range(-wEdge, wEdge);
        r2 = new range(-hEdge, hEdge);
        r3 = new range(0, window.innerWidth);
        r4 = new range(0, window.innerHeight);

        var convert = function (param, range1Start, range1End, range2Start, range2End) {
            return ((param - range1Start) * (range2End - range2Start) /
                (range1End - range1Start) + range2Start);
        }
        x = convert(data.lon, r1.start, r1.end, r3.start, r3.end);
        y = convert(data.lat, r2.start, r2.end, r4.start, r4.end);
        var plane = new Image()
        plane.onload = function () {
            var planeSize = 35;
            ctx.drawImage(plane, x - planeSize / 2,
                y - planeSize / 2, planeSize, planeSize);

        }
        plane.src = "../../../Content/airplane-icon.png";
    }
})(jQuery);