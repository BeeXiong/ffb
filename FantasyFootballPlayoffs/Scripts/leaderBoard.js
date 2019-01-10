$(document).ready(function () {
    var leaderBoard = sortLeaderBoard();

    leaderBoardApp.firstPlaceName = leaderBoard[0].name;
    leaderBoardApp.firstPlaceScore = leaderBoard[0].score;
    leaderBoardApp.firstPlaceRemaining = leaderBoard[0].remaining;
    leaderBoardApp.secondPlaceName = leaderBoard[1].name;
    leaderBoardApp.secondPlaceScore = leaderBoard[1].score;
    leaderBoardApp.secondPlaceRemaining = leaderBoard[1].remaining;
    leaderBoardApp.thirdPlaceName = leaderBoard[2].name;
    leaderBoardApp.thirdPlaceScore = leaderBoard[2].score;
    leaderBoardApp.thirdPlaceRemaining = leaderBoard[2].remaining;
    leaderBoardApp.fourthPlaceName = leaderBoard[3].name;
    leaderBoardApp.fourthPlaceScore = leaderBoard[3].score;
    leaderBoardApp.fourthPlaceRemaining = leaderBoard[3].remaining;
    leaderBoardApp.fifthPlaceName = leaderBoard[4].name;
    leaderBoardApp.fifthPlaceScore = leaderBoard[4].score;
    leaderBoardApp.fifthPlaceRemaining = leaderBoard[4].remaining;
    leaderBoardApp.lastPlaceName = leaderBoard[5].name;
    leaderBoardApp.lastPlaceScore = leaderBoard[5].score;
    leaderBoardApp.lastPlaceRemaining = leaderBoard[5].remaining;
});

function sortLeaderBoard() {
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

    var teamOneNameRemaining = $("#0-Remaining").text();
    var teamTwoNameRemaining = $("#1-Remaining").text();
    var teamThreeNameRemaining = $("#2-Remaining").text();
    var teamFourNameRemaining = $("#3-Remaining").text();
    var teamFiveNameRemaining = $("#4-Remaining").text();
    var teamSixNameRemaining = $("#5-Remaining").text();

    var leaderBoard = [
        { name: "" + teamOneName + "", score: "" + teamOnePoints + "", remaining: "" + teamOneNameRemaining + "" },
        { name: "" + teamTwoName + "", score: "" + teamTwoPoints + "", remaining: "" + teamTwoNameRemaining + "" },
        { name: "" + teamThreeName + "", score: "" + teamThreePoints + "", remaining: "" + teamThreeNameRemaining + "" },
        { name: "" + teamFourName + "", score: "" + teamFourPoints + "", remaining: "" + teamFourNameRemaining + "" },
        { name: "" + teamFiveName + "", score: "" + teamFivePoints + "", remaining: "" + teamFiveNameRemaining + "" },
        { name: "" + teamSixName + "", score: "" + teamSixPoints + "", remaining: "" + teamSixNameRemaining + "" }
    ];

    return leaderBoard.sort(function (a, b) { return b.score - a.score; });
}

var leaderBoardApp = new Vue({
    el: '#leaderBoardApp',
    data: {
        firstPlaceName: "",
        firstPlaceScore: 0,
        firstPlaceRemaining: 0,
        secondPlaceName: "",
        secondPlaceScore: 0,
        secondPlaceRemaining: 0,
        thirdPlaceName: "",
        thirdPlaceScore: 0,
        thirdPlaceRemaining: 0,
        fourthPlaceName: "",
        fourthPlaceScore: 0,
        fourthPlaceRemaining: 0,
        fifthPlaceName: "",
        fifthPlaceScore: 0,
        fifthPlaceRemaining: 0,
        lastPlaceName: "",
        lastPlaceScore: 0,
        lastPlaceRemaining: 0
    }
});