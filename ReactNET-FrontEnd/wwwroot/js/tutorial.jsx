const CommentBox = (props) => {
    const [count, setCount] = React.useState(0);
    const [apiData, setApiData] = React.useState([]);

    React.useEffect(() => {
        fetchData();
        console.log("Hi from useEffect");
    }, []);

    const fetchData = () => {
        const xhr = new XMLHttpRequest();
        xhr.open('get', props.url, true);
        xhr.onload = () => {
            const data = JSON.parse(xhr.responseText);
            setApiData(data);
        };
        xhr.send();
    }

    return (
        <div className="commentBox">Hello, world! I am a CommentBox.
            <div>
                <button onClick={() => setCount((prev) => prev + 1)}>Add One</button>
                <div>count: {count}</div>
            </div>
            {/* I just want to render the json data fetched from server here */}
            {apiData.length > 0 && apiData.map((item, i) => <div key={i}>{item.id} {item.author} <br/> {item.text}</div>) }
        </div>
        );
}

ReactDOM.render(<CommentBox url="/comments"/>, document.getElementById('content'));
