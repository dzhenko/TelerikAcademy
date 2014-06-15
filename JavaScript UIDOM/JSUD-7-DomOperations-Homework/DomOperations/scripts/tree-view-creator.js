function createTreeView(elementToCreateTreeView) {
    var allLi = elementToCreateTreeView.getElementsByTagName('li');

    for (var i = 0; i < allLi.length; i++) {

        //making all childs invisible
        var child = allLi[i].firstElementChild;
        while (child) {
            child.style.display = 'none';
            child = child.nextElementSibling;
        }

        //setting the onclickFunction
        allLi[i].onclick = function (event) {

            //delete this and the function will go to the parent element as well
            event.stopPropagation();

            var currChild = this.firstElementChild;

            while (currChild) {
                if (currChild.style.display == 'none') {
                    currChild.style.display = 'block';
                }
                else {
                    currChild.style.display = 'none';
                }

                currChild = currChild.nextElementSibling;
            }
        };
    }
}