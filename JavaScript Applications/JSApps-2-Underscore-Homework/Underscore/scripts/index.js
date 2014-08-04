/// <reference path="allTasks.js" />
window.addEventListener('load', function () {
    var result = document.getElementById('result');
    var taskNum = 0;
    var option = 'Result';

    document.getElementById('tasks').addEventListener('click', function (ev) {
        if (ev.target instanceof HTMLAnchorElement) {
            taskNum = parseInt(ev.target.innerHTML) - 1;
            showAction();
        }
    });

    var ulList = document.getElementById('options');
    ulList.addEventListener('click', function (ev) {
        option = ev.target.innerHTML;
        showAction();
    });

    function showAction() {
        if (option == 'Result') {
            result.innerHTML = JSON.stringify(allTasks.tasks[taskNum]());
        }
        else if (option == 'Code') {
            result.innerHTML = JSON.stringify(allTasks.tasks[taskNum].toString());
        }
        else {
            if (taskNum == 0 || taskNum == 1 || taskNum == 2 || taskNum == 6) {
                result.innerHTML = JSON.stringify(data.students);
            }
            else if (taskNum == 3 || taskNum == 4) {
                result.innerHTML = JSON.stringify(data.animals);
            }
            else if (taskNum == 5) {
                result.innerHTML = JSON.stringify(data.books);
            }
        }
    }

    showAction();
});