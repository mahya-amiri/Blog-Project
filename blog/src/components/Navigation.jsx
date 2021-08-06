import React from "react";
import { BrowserRouter as Router, Switch, Route, Link } from "react-router-dom";
import Articles from "./Articles";

export default function App() {
  return (
    <Router>
      <div className="nav content-right" dir="rtl">
        <nav>
          <Link to="/">صفحه ی اصلی</Link>
          <span className="mx-2">|</span>
          <Link to="/article">مقالات</Link>
          <span className="mx-2">|</span>
          <Link to="/about">درباره ی ما</Link>
        </nav>

        <Switch>
          <Route path="/about">
            <About />
          </Route>
          <Route path="/article">
            <Article />
          </Route>
          <Route path="/">
            <Home />
          </Route>
        </Switch>
      </div>
    </Router>
  );
}

function Home() {
  return <h2>Home</h2>;
}

function About() {
  return <h2>About</h2>;
}
function Article() {
  return <Articles></Articles>;
}
