function SortByTwoCriteria(arr) {
    arr.sort((a, b) => {
        return a.length - b.length || a.localeCompare(b);
    });

    console.log(arr.join('\n'));
}