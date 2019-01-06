        $(function () {
            // Reference the auto-generated proxy for the hub.
            var chat = $.connection.draftHub;

            // Create a function that the hub can call back to display messages.
            chat.client.addNewMessageToPage = function (name, message) {
                // Add the message to the page.
                $('#discussion').prepend('<li><strong>' + htmlEncode(name)
                    + '</strong> ' + htmlEncode(message) + '</li>');
            };

            //Create a function that the hub can call back to deactivate the button of the player who was just selected.
            chat.client.deactivateSelectedPlayerBtn = function (elementId) {
                //use elementId + jquery to change class to btn-success and deactive button
                $('#' + elementId).html('Drafted');
                $('#' + elementId).removeClass('btn-primary').addClass('btn-success').addClass('draftBtnDisable');
                $('#' + elementId).attr("disabled");
            };

            //Create a function that the hub can call back to change the last pick information
            chat.client.updateLastPick = function (playerName, teamName, playerPosition, pickNumber, userName) {
                $('#lastPickName').html(playerName);
                $('#lastPickPosition').html(playerPosition);
                $('#lastPickTeam').html(teamName);
                $('#lastPickUserName').html(userName);
                $('#lastPickNumber').html(pickNumber);
            };

            //Create a function that the hub can call back to update the user's team table
            chat.client.updateTeamTable = function (userTeam, detailsId) {
                if (detailsId === parseInt($('#FantasyLeagueDetail').val())) {
                    //remove old team table and create new table body
                    $('#teamTableInfo').remove();
                    $('#myTeamTable').append('<tbody id=teamTableInfo></tbody');

                    //loop through and create rows with array
                    for (var i = 0; i < userTeam.length; i++) {
                        var currentRow = userTeam[i];
                        $('#teamTableInfo').append('<tr><td>' + currentRow[0] + '</td><td>' + currentRow[1] + '</td><td>' + currentRow[2] + '</td><td>' + currentRow[3] + '</td></tr>');
                    }
                }
            };
            //Create a function that the hub can call back to update the draft order
            chat.client.updateDraftOrder = function () {
                //when pick is made removes first element of draftboard
                $('#draftBoard').children().first().remove();
            };

            chat.client.reloadForDraftOrder = function () {
                location.reload();
            };

            // Set initial focus to message input box.
            $('#message').focus();
            // Start the connection.
            $.connection.hub.start().done(function () {
                var leagueName = $('#leagueName').html();
                chat.server.addUserToChatRoom(leagueName);

                //send chat message using interface
                $('#sendmessage').click(function () {
                    // Call the Send method on the hub.
                    chat.server.send($('#displayname').val(), $('#message').val(), leagueName);
                    // Clear text box and reset focus for next comment.
                    $('#message').val('').focus();
                });

                //draft player using interface
                $('.draftBtn').click(function () {
                    //Validate that it's user's turn to make selection
                    var clientUserName = $('#displayname').val();
                    var userToPickNext = $('#draftBoard').children().first().children().last().text(); // last Grand Child Element to find user name
                    if (clientUserName === userToPickNext) {

                        //update selection button with new pick, update last pick information, update current user team table

                        //get button element id
                        var btnid = $(this).prop("id");
                        //get hidden player id
                        var playerId = $(this).next().val();
                        //move to the next element and get hidden details Id
                        var detailsHidden = $(this).next();
                        var detailsId = detailsHidden.next().val();

                        //DOM traversing to get parent element (table data) and getting previous siblings
                        var tdElements = $(this).parent();
                        tdElements = tdElements.prev();
                        //gets the value of that table data
                        var lastPickPosition = tdElements.html();
                        tdElements = tdElements.prev();
                        var lastPickTeam = tdElements.html();
                        tdElements = tdElements.prev();
                        var lastPickName = tdElements.html();
                        var lastPickNumber = parseInt($('#lastPickNumber').html()) + 1;

                        //create list of arrays from the team table to pass to function
                        var userTeam = [];
                        $('#teamTableInfo tr').each(function () {
                            var row = [];
                            $(this).find("td").each(function () {
                                value = $(this).html();
                                row.push(value);
                            });
                            userTeam.push(row);
                        });

                        chat.server.receiveSelection(playerId, detailsId, btnid, lastPickName, lastPickTeam, lastPickPosition, lastPickNumber, userTeam, leagueName);
                    }
                    else {
                        //do nothing because incorrect user tried to make selection
                    }
                });
                $('#draftOrderBtn').click(function () {
                    var leagueId = parseInt($('#FantasyLeagueId').val());
                    var leagueCount = parseInt($('#FantasyLeagueCount').val());
                    var roomName = $('#leagueName').html();

                    chat.server.determineDraftOrder(leagueCount, leagueId, roomName);
                });
            });

            $.connection.hub.disconnected(function () {
                setTimeout(function () {
                    location.reload();
                }, 3000); // Restart connection after 5 seconds.
            });

        });
// This optional function html-encodes messages for display in the page.
function htmlEncode(value) {
    var encodedValue = $('<div />').text(value).html();
    return encodedValue;
}