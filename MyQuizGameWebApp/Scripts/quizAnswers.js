$(document).ready(function () {
    var addAnswerButton = document.getElementById("add-answer-button"),
        answerDiv = document.getElementById("answers-box"),
        nextId = 0,
        answerHtmlTemplate = "";

    addAnswerButton.addEventListener("click", function () {
        var newAnswerDiv = document.createElement("div"),
            thisId = nextId++;

        newAnswerDiv.innerHTML = answerHtmlTemplate.replace(new RegExp("{{id}}", 'g'), thisId);

        answerDiv.appendChild(newAnswerDiv);
    });

    answerHtmlTemplate = '<div>' +
        '<div>' +
        '    <label for="Answers[{{id}}].Content" class="control-label">Content:</label>' +
        '    <textarea id="Answers[{{id}}].Content" name="Answers[{{id}}].Content" class="form-control" ></textarea>' +
        '</div>' +
        '<div>' +
        '    <label for="Answers[{{id}}].IsCorrect" class="control-label">Is Correct:</label>' +
        '   <input type="checkbox" id="Answers[{{id}}].IsCorrect" name="Answers[{{id}}].IsCorrect" value="true" class="form-control" />' +
        '    <input type="hidden" id="Answers[{{id}}].IsCorrect" name="Answers[{{id}}].IsCorrect" value="false" />' +
        '</div>' +
        '</div>';
});