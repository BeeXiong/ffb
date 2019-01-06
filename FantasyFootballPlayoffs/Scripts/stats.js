$(document).ready(function () {
    $("#submitNewGame").on('click', function () {
        var isSelected = checkTeamDropDowns();
        if (isSelected === true) {
            postNewGameToDB();
        }
        else {
            $("#teamSelectError").append("<div class='alert alert-danger' role='alert'>Please Make Sure Both Teams Are Selected</div>");
        }
    });
    $('#submitStat').on('click', function () {
        saveStat();
        location.reload();
    });
});
function checkTeamDropDowns(){
    var homeTeam = $("#HomeTeam").val();
    var awayTeam = $("#AwayTeam").val();
    var year = $("#year").val();

    if (homeTeam !== "" && awayTeam !== "" && year !== "") {
        return true;
    }
    else{
        return false;
    }
}
function postNewGameToDB(){
    teamData = { homeTeamId: -1, awayTeamId: -1, gameYearId: -1, sportId: -1, isactive: "N", playoffRoundId: -1 };

    teamData.homeTeamId = $("#HomeTeam").val(),
    teamData.awayTeamId = $("#AwayTeam").val(),
    teamData.gameYearId = $("#year").val(),
    teamData.sportId = $("#sportDropdown").val(),
    teamData.playoffRoundId = $("#playoffRound").val(),
    teamData.isactive = "Y",
    teamData.id = $("#id").val(),

    $.ajax({
        type: "POST",
        url: "/stats/createGames",
        data: JSON.stringify(teamData),
        datatype: "json",
        contentType: "application/json; charset=utf-8",
        success: function(data){
            location.reload();
        },
        error:{

        }
    });    
}
function deleteGame(buttonElement) {  
    data = { gameId: -1 };
    data.gameId = buttonElement.dataset.gameid;
    $.ajax({
        type: "POST",
        url: "/stats/gameDelete",
        data: JSON.stringify(data),
        datatype: "json",
        contentType: "application/json; charset=utf-8",
        success: function (data) {
            location.reload();
        },
        error: {

        }
    });
}
function saveStat() {
    gameStat = {
        Id: -1,
        playerId: -1,
        gameId: -1,
        statisticalCategoryid: -1,
        passAttempt: false,
        passCompletion: false,
        passYards: -1,
        isAPassTouchdown: false,
        isAinterception: false,
        rushAttempt: false,
        rushYards: -1,
        isARushTouchdown: false,
        isAFumble: false,
        target: false,
        reception: false,
        recYards: -1,
        isARecTouchdown: false,
        isAtdbetween35_49: false,
        isAtdOver50: false,
        isA2Point: false,
        isASack: false,
        isADefensiveTD: false,
        isAFumbleRecovery: false,
        PAT: false,
        isAFG39: false,
        isAFG49: false,
        isAFG59: false,
        isAFG60: false,
        points0: false,
        points7: false,
        points20: false,
        points27: false,
        points34: false,
        points35: false,
        points: -1,
        statisticCategoryQuantity: -1

    };

    gameStat.Id = $("#id").val();
    gameStat.gameId = $("#gameId").val();
    gameStat.playerId = $("#gamePlayer").val();

    if ($("#statCategory").val() === "") {
        gameStat.statisticalCategoryid = null;
    }
    else {
        gameStat.statisticalCategoryid = $("#statCategory").val();
    }

    if ($("#StatQuantity").val() === "") {
        gameStat.statisticCategoryQuantity = null;
    }
    else {
        gameStat.statisticCategoryQuantity = $("#StatQuantity").val();
    }

    if ($("#PassAtt").is(':checked') === true) {
        gameStat.passAttempt = true;
    }

    if ($("#PassCom").is(':checked') === true) {
        gameStat.passCompletion = true;
    }

    if ($("#PassYards").val() === "") {
        gameStat.passYards = null;
    }
    else {
        gameStat.passYards = $("#PassYards").val();
    }

    if ($("#PassTD").is(':checked') === true) {
        gameStat.isAPassTouchdown = true;
    }

    if ($("#PassInt").is(':checked') === true) {
        gameStat.isAinterception = true;
    }
    
    if ($("#RushAtt").is(':checked') === true) {
        gameStat.rushAttempt = true;
    }

    if ($("#RushYards").val() === "") {
        gameStat.rushYards = null;
    }
    else {
        gameStat.rushYards = $("#RushYards").val();
    }
    
    if ($("#RushTD").is(':checked') === true) {
        gameStat.isARushTouchdown = true;
    }

    if ($("#Fumble").is(':checked') === true) {
        gameStat.isAFumble = true;
    }

    if ($("#Target").is(':checked') === true) {
        gameStat.target = true;
    }

    if ($("#Catch").is(':checked') === true) {
        gameStat.reception = true;
    }

    if ($("#RecTD").is(':checked') === true) {
        gameStat.isARecTouchdown = true;
    }

    if ($("#RecYards").val() === "") {
        gameStat.recYards = null;
    }
    else {
        gameStat.recYards = $("#RecYards").val();
    }

    if ($("#Sack").is(':checked') === true) {
        gameStat.isASack = true;
    }
    if ($("#Int").is(':checked') === true) {
        gameStat.isAinterception = true;
    }
    if ($("#DefTD").is(':checked') === true) {
        gameStat.isADefensiveTD = true;
    }

    if ($("#FumRec").is(':checked') === true) {
        gameStat.isAFumbleRecovery = true;
    }

    if ($("#Safety").is(':checked') === true) {
        gameStat.isASafety = true;
    }

    if ($("#TD35_49").is(':checked') === true) {
        gameStat.isAtdbetween35_49 = true;
    }

    if ($("#TDOver50").is(':checked') === true) {
        gameStat.isAtdOver50 = true;
    }

    if ($("#2ptCon").is(':checked') === true) {
        gameStat.isA2Point = true;
    }

    if ($("#PAT").is(':checked') === true) {
        gameStat.PAT = true;
    }

    if ($("#isAFG39").is(':checked') === true) {
        gameStat.isAFG39 = true;
    }

    if ($("#isAFG49").is(':checked') === true) {
        gameStat.isAFG49 = true;
    }

    if ($("#isAFG59").is(':checked') === true) {
        gameStat.isAFG59 = true;
    }

    if ($("#isAFG60").is(':checked') === true) {
        gameStat.isAFG60 = true;
    }

    if ($("#points0").is(':checked') === true) {
        gameStat.points0 = true;
    }

    if ($("#points7").is(':checked') === true) {
        gameStat.points7 = true;
    }

    if ($("#points20").is(':checked') === true) {
        gameStat.points20 = true;
    }

    if ($("#points27").is(':checked') === true) {
        gameStat.points27 = true;
    }

    if ($("#points34").is(':checked') === true) {
        gameStat.points34 = true;
    }

    if ($("#points35").is(':checked') === true) {
        gameStat.points35 = true;
    }

    $.ajax({
        type: "POST",
        url: "/stats/saveStat",
        data: JSON.stringify(gameStat),
        datatype: "json",
        contentType: "application/json; charset=utf-8",
        success: function (data) {
            location.reload();
        },
        error: {

        }
    });
}
//function editStat(buttonElement) {
//    data = { statId: -1 };
//    data.statId = buttonElement.dataset.statid;
//    $.ajax({
//        type: "POST",
//        url: "/stats/editStat",
//        data: JSON.stringify(data),
//        datatype: "json",
//        contentType: "application/json; charset=utf-8",
//        success: function (data) {
//            var x = true
//        },
//        error: {

//        }
//    });
//}
function deleteStat(buttonElement) {
    data = { statId: -1 };
    data.statId = buttonElement.dataset.statid;
    $.ajax({
        type: "POST",
        url: "/stats/deleteStat",
        data: JSON.stringify(data),
        datatype: "json",
        contentType: "application/json; charset=utf-8",
        success: function (data) {
            //location.reload();
        },
        error: {

        }
    });
}