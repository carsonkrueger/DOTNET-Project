const CommentBox = (props) => {
    const [count, setCount] = React.useState(0);
    return (
        <div className="commentBox">Hello, world! I am a CommentBox.
            <div>
                <button onClick={() => setCount((prev) => prev + 1)}>Add One</button>
                <div>count: {count}</div>
            </div>
        </div>
        );
}

ReactDOM.render(<CommentBox url="/comments"/>, document.getElementById('content'));
