function appendTODOList(holder) {
    var newItemB = document.createElement('button');
    var showHideB = document.createElement('button');

    holder.appendChild(newItemB);
    holder.appendChild(showHideB);

    var inputNewItemHolder = document.createElement('div');

    var inputNewItem = document.createElement('input');
    var addItemB = document.createElement('button');
    inputNewItemHolder.appendChild(inputNewItem);
    inputNewItemHolder.appendChild(addItemB);

    holder.appendChild(inputNewItemHolder);

    var itemsHolder = document.createElement('div');
    holder.appendChild(itemsHolder);

    (function generateStyles() {
        itemsHolder.id = 'itemsHolder';
        itemsHolder.style.width = '500px';
        itemsHolder.style.minHeight = '55px';
        itemsHolder.style.display = 'block';
        itemsHolder.style.border = '1px solid black';
        inputNewItemHolder.style.display = 'none';
        addItemB.innerHTML = 'Add This Item';
        inputNewItem.style.width = '400px';
        newItemB.innerHTML = 'CREATE NEW ITEM';
        showHideB.innerHTML = 'SHOW/HIDE ITEMS';
    })();

    newItemB.addEventListener('click', function () {
        if (inputNewItemHolder.style.display == 'block') {
            inputNewItemHolder.style.display = 'none';
        }
        else {
            inputNewItemHolder.style.display = 'block';
        }

    }, false)

    addItemB.addEventListener('click', upDateList, false);

    function upDateList() {
        if (inputNewItem.value == "") {
            return;
        }

        var currDiv = document.createElement('div');

        var removeB = document.createElement('button');
        removeB.innerHTML = 'REMOVE';

        removeB.addEventListener('click', function () {
            itemsHolder.removeChild(this.parentElement);
        }, false)

        currDiv.appendChild(removeB);

        var currText = document.createElement('span');
        currText.innerHTML = inputNewItem.value;
        inputNewItem.value = "";
        currText.style.marginLeft = '15px';
        currDiv.appendChild(currText);

        itemsHolder.appendChild(currDiv);
    }

    showHideB.addEventListener('click', function () {
        if (itemsHolder.style.display == 'block') {
            itemsHolder.style.display = 'none';
        }
        else {
            itemsHolder.style.display = 'block';
        }
    }, false)
}