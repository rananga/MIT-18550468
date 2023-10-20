$(function () {
    var btnExpAll = $('#btnExpAll');
    var btnColapsAll = $('#btnColapsAll');
    var btnCheckAll = $('#btnCheckAll');
    var btnUnchkAll = $('#btnUnchkAll');
    var btnCheckAllGrades = $('#btnCheckAllGrades');
    var btnUnchkAllGrades = $('#btnUnchkAllGrades');
    var btnSave = $('#btnSave');
    var menusJson = $('#MenusJson');
    var gradesJson = $('#GradesJson');
    var ulTreeMenu = $('ul.tree#tree_menu');
    var ulTreeGrade = $('ul.tree#tree_grade');

    btnSave.click(function () {
        event.preventDefault();
        var menus = [];
        var grades = [];

        $('.glyphicon-check,.glyphicon-expand', ulTreeMenu).each(function () {
            var $li = $(this).parent('li');
            var itm = { MenuId: $li.data('menu-id'), ActionId: $li.data('menu-action-id') };
            menus.push(itm);
        });
        menusJson.val(JSON.stringify(menus));

        $('.glyphicon-check,.glyphicon-expand', ulTreeGrade).each(function () {
            grades.push($(this).parent('li').data('grade-id'));
        });
        gradesJson.val(JSON.stringify(grades));

        $(this).closest('form').submit();
    });


    $('.glyphicon', ulTreeMenu).add('.glyphicon', ulTreeGrade).each(function () {
        var icn = $(this);
        var li = icn.parent('li');
        icn.click(function () {
            if (icn.is('.glyphicon-plus')) {
                exapndNode(li);
            }
            else if (icn.is('.glyphicon-minus')) {
                collapseNode(li);
            }
            else if (btnCheckAll.length > 0) {
                if (icn.is('.glyphicon-check') || icn.is('.glyphicon-expand')) {
                    uncheckNode(li, true);
                }
                else if (icn.is('.glyphicon-unchecked')) {
                    checkNode(li, true);
                }
            }
        });
    });

    btnExpAll.click(function () {
        ulTreeMenu.children('li').each(function () { exapndNode($(this), true) });
    });

    btnColapsAll.click(function () {
        ulTreeMenu.children('li').each(function () { collapseNode($(this)) });
    });

    btnCheckAll.click(function () {
        ulTreeMenu.children('li').each(function () { checkNode($(this)) });
    });

    btnUnchkAll.click(function () {
        ulTreeMenu.children('li').each(function () { uncheckNode($(this)) });
    });

    btnCheckAllGrades.click(function () {
        ulTreeGrade.children('li').each(function () { checkNode($(this)) });
    });

    btnUnchkAllGrades.click(function () {
        ulTreeGrade.children('li').each(function () { uncheckNode($(this)) });
    });

    function exapndNode(node, all) {
        var liSpans = node.children('span');
        if (liSpans.length > 1) {
            liSpans.eq(0).removeClass();
            liSpans.eq(0).addClass("glyphicon glyphicon-minus");
        }
        var ul = node.children('ul');
        ul.show();

        if (all)
            ul.children('li').each(function () { exapndNode($(this)) });
    }

    function collapseNode(node) {
        var liSpans = node.children('span');
        if (liSpans.length > 1) {
            liSpans.eq(0).removeClass();
            liSpans.eq(0).addClass("glyphicon glyphicon-plus");
        }
        var ul = node.children('ul');
        ul.hide();
        ul.children('li').each(function () { collapseNode($(this)) });
    }

    function checkNode(node, setInd) {
        var liSpans = node.children('span');

        liSpans.eq(-1).removeClass();
        liSpans.eq(-1).addClass("glyphicon glyphicon-check");

        node.children('ul').children('li').each(function () { checkNode($(this)) });

        if (setInd) { setIndeterminate(node); }
    }

    function uncheckNode(node, setInd) {
        var liSpans = node.children('span');

        liSpans.eq(-1).removeClass();
        liSpans.eq(-1).addClass("glyphicon glyphicon-unchecked");

        node.children('ul').children('li').each(function () { uncheckNode($(this)) });

        if (setInd) { setIndeterminate(node); }
    }

    function setIndeterminate(node) {
        var chkd = node.children('span').eq(-1).is(".glyphicon-check");

        var ulPrnt = node.parent('ul');
        var prnt = ulPrnt.parent('li');

        if (prnt.length == 0) {
            return;
        }

        var lis = ulPrnt.children('li');
        var chkCnt = 0;
        var idmntCnt = 0;

        lis.each(function () {
            var liChkd = $(this).children('span').eq(-1).is(".glyphicon-check");
            var liIdmnt = $(this).children('span').eq(-1).is(".glyphicon-expand");

            if (liChkd) {
                chkCnt++;
            }
            if (liIdmnt) {
                idmntCnt++;
            }
        });

        var liSpans = prnt.children('span');
        liSpans.eq(-1).removeClass();

        if (chkCnt == 0 && idmntCnt == 0) {
            liSpans.eq(-1).addClass("glyphicon glyphicon-unchecked");
        }
        else if (lis.length == chkCnt) {
            liSpans.eq(-1).addClass("glyphicon glyphicon-check");
        }
        else {
            liSpans.eq(-1).addClass("glyphicon glyphicon-expand");
        }

        setIndeterminate(prnt);
    }

    function setMenusFromJson() {
        var val = menusJson.val();
        if (!IsJson(val)) {
            return;
        }
        var jsn = JSON.parse(val);

        ulTreeMenu.children('li').each(function () { checkNode($(this)) });

        $('li[data-menu-id]', ulTreeMenu).each(function () {
            var li = $(this);
            if (li.children('ul').length > 0) { return; }

            if (jsn.find(x => x.MenuId == li.data('menu-id') && x.ActionId == li.data('menu-action-id'))) { checkNode(li); }
            else { uncheckNode(li); }
        });

        $('ul > li:first-child', ulTreeMenu).each(function () { setIndeterminate($(this)) });
    }

    function setGradesFromJson() {
        var val = gradesJson.val();
        if (!IsJson(val)) {
            return;
        }
        var jsn = JSON.parse(val);

        ulTreeGrade.children('li').each(function () { checkNode($(this)) });

        $('li[data-grade-id]', ulTreeGrade).each(function () {
            var li = $(this);
            if (li.children('ul').length > 0) { return; }

            if ($.inArray(li.data('grade-id'), jsn) >= 0) { checkNode(li); }
            else { uncheckNode(li); }
        });

        $('ul > li:first-child', ulTreeGrade).each(function () { setIndeterminate($(this)) });
    }
    setMenusFromJson();
    setGradesFromJson();
});