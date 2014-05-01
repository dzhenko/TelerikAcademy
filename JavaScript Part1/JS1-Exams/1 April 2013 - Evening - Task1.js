/*http://bgcoder.com/Contests/75/JavaScript-1-April-2013-Evening*/

function Solve(params) {
    var nums = [];
    var allNegative = true;
    var maxNum = -2000001;
    for (var i=1;i < params.length;i++) {
        var currNum = parseInt(params[i]);
        if (currNum >=0) {
            allNegative = false;
        }
        if (allNegative && currNum > maxNum) {
            maxNum = currNum;
        }
        nums.push(currNum);
    }
    if (allNegative) {
        return maxNum;
    }
    var sum = 0;
    var absoluteMax = 0;
    for (var i=0;i < nums.length;i++) {
        sum = Math.max(nums[i],nums[i] + sum);
        absoluteMax = Math.max(absoluteMax,sum);
    }
    return absoluteMax;
}