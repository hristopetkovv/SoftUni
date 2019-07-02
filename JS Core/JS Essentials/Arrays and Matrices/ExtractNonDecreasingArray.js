function main(arr) {
    console.log(arr[0]);

    for(let i = 1; i <= arr.length; i++) {
        if(arr[i] >= arr[i - 1]) {
            console.log(arr[i]);
        }
    }
}
main([1, 
    2, 
    3,
    4]
    )