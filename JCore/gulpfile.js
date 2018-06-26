"use strict";
var gulp = require("gulp"),
    rimraf = require("rimraf"),
    concat = require("gulp-concat"),
    cssmin = require("gulp-cssmin"),
    uglify = require("gulp-uglify")

var paths = {
    webroot: "./wwwroot/"
};
paths.node_modules_libs = [
    'node_modules/font-awesome/**'
]
paths.lib = paths.webroot + 'lib/*.js';
paths.js = paths.webroot + "js/**/*.js";
paths.minJs = paths.webroot + "js/**/*.min.js";
paths.concatJsDest = paths.webroot + "js/site.min.js";

gulp.task('lib', function () {     //����npm����web root��
    gulp.src(paths.node_modules_libs).pipe(gulp.dest(paths.webroot + 'lib/font-awesome'))
});

gulp.task("clean:js", function (cb) {   //����ѹ�����js�ļ�
    rimraf(paths.concatJsDest, cb);
});
gulp.task("min:js", function () {  //����Ҫ��jsѹ�����ϲ���һ���ļ��Լ���http������
    gulp.src([paths.js, "!" + paths.minJs, paths.lib], { base: "." }).pipe(concat(paths.concatJsDest))
        .pipe(uglify())
        .pipe(gulp.dest("."));
});