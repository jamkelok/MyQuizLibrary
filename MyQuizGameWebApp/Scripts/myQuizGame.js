$(document).ready(function () {
    var nextQuestionButton = document.getElementById('next-question-button'),
        questionArea = document.getElementById('question-area'),
        answerArea = document.getElementById('answer-area'),
        currentQuestionId;
    
    var clickHandler = function clickHandler(event) {

        var anwserSubmission = { questionId: currentQuestionId, answerId: event.currentTarget.id };

        // Lokesh : the below is only for a quick check before the actual json

        // alert(anwserSubmission.questionId + " " + anwserSubmission.answerId);

        // Lokesh - I commented the below jSon so that I can do a hit test using the above first
          
        $.getJSON("/api/quizquestion/isanswercorrect/", anwserSubmission)
            .done(function (data) {
                if (data.IsCorrect) {
                    alert("Congratulations! That's right!");

                   

                } else {
                    alert("Sorry! That wasn't correct!");
                }
            })
            .fail(function (jqxhr, textStatus, error) {
                alert("Whoops! Something went wrong!");
            });
            
        // Lokesh - end comment
    }

    // comment here if you want to do a hit test first 
    
     
    nextQuestionButton.addEventListener('click', function () 
    {
        $.getJSON('/api/quizquestion', function (data) {
            var questionDiv = document.createElement('div');
            questionArea.innerHTML = "<p><bold>Question</bold></p>";
                     
            currentQuestionId = data.QuestionId;
            questionArea.id = currentQuestionId;
            questionDiv.classList.add('well');
            questionDiv.classList.add('small');
            questionArea.appendChild(questionDiv);

            questionDiv.innerText = data.Content;

            answerArea.innerHTML = "Answers";

            data.Answers.forEach(function (val) {
                var answerDiv = document.createElement('div');
                answerDiv.classList.add('pointer');
                answerDiv.classList.add('well');
                answerDiv.innerText = val.Content;
                answerDiv.id = val.AnswerId;
                answerDiv.addEventListener('click', clickHandler);
                answerArea.appendChild(answerDiv);
            });
        });
    });
    
    // end hit test check 
   
});