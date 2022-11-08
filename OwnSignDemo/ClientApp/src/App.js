import { Routes, Route } from "react-router-dom"
import { FrontLayout } from "./pages/Front"
import Title from "./pages/Front/Title"
import NotFound from "./pages/Special/NotFound"

import './App.css';

const App = () => {
  return (
    <>
    <Routes>
      <Route path='/' element={<FrontLayout />}>
        <Route index element={<Title />} />
      </Route>
      <Route path="*" element={<NotFound />} />
    </Routes>
    </>
  );
}

export default App;