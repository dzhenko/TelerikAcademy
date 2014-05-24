function original() {
function f(n){return n==0?1:n*f(n-1)}a=arguments[0];return f(2*a)/((a+1)*f(a)*4)
}



function solve() {
    function fact(num) {
        return num == 0 ? 1 : num * fact(num - 1);
    }

    input = arguments[0];

    var answer = fact(2 * input) / (fact(1 + input) * fact(input) * 2);
    return answer
}

(function(a){return[1,1,2,5,14,42,132,429,1430,4862,16796,58786][a[0]]/2})