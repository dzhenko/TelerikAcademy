function BiggerThanNeighbours(arr,position) {
    if (position >= arr.length) {
        return false;
    }

    if (arr[position] == 0 || arr[position] == arr.length - 1) {
        return false;
    }

    if (arr[position] > arr[position-1] && arr[position] > arr[position+1]) {
        return true;
    }
    else {
        return false;
    }
}