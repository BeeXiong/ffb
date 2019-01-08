$(document).ready(function () {
    var teamOnePoints = parseFloat($("#0-TotalPoints").text());
    var teamTwoPoints = parseFloat($("#1-TotalPoints").text());
    var teamThreePoints = parseFloat($("#2-TotalPoints").text());
    var teamFourPoints = parseFloat($("#3-TotalPoints").text());
    var teamFivePoints = parseFloat($("#4-TotalPoints").text());
    var teamSixPoints = parseFloat($("#5-TotalPoints").text());

    var teamOneName = $("#0-teamName").text();
    var teamTwoName = $("#1-teamName").text();
    var teamThreeName = $("#2-teamName").text();
    var teamFourName = $("#3-teamName").text();
    var teamFiveName = $("#4-teamName").text();
    var teamSixName = $("#5-teamName").text();

    var leaderBoard = [
        { name: "" + teamOneName + "", score: "" + teamOnePoints + "" },
        { name: "" + teamTwoName + "", score: "" + teamTwoPoints + "" },
        { name: "" + teamThreeName + "", score: "" + teamThreePoints + "" },
        { name: "" + teamFourName + "", score: "" + teamFourPoints + "" },
        { name: "" + teamFiveName + "", score: "" + teamFivePoints + "" },
        { name: "" + teamSixName + "", score: "" + teamSixPoints + "" }
    ]

    leaderBoard.sort(function (a, b) { return b.score - a.score })

    $("#firstPlace").html("" + leaderBoard[0].name + ": ")
    $("#firstPlaceScore").html("" + leaderBoard[0].score + "")

    $("#secondPlace").html("" + leaderBoard[1].name + ": ")
    $("#secondPlaceScore").html("" + leaderBoard[1].score + "")

    $("#thirdPlace").html("" + leaderBoard[2].name + ": ")
    $("#thirdPlaceScore").html("" + leaderBoard[2].score + "")

    $("#fourthPlace").html("" + leaderBoard[3].name + ": ")
    $("#fourthPlaceScore").html("" + leaderBoard[3].score + "")

    $("#fifthPlace").html("" + leaderBoard[4].name + ": ")
    $("#fifthPlaceScore").html("" + leaderBoard[4].score + "")

    $("#lastPlace").html("" + leaderBoard[5].name + ": ")
    $("#lastPlaceScore").html("" + leaderBoard[5].score + "")
});