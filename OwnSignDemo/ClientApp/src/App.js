import { Routes, Route } from "react-router-dom"
import { FrontLayout } from "./pages/Front"
import { AuthLayout } from "./pages/Auth"
import { UsersLayout } from "./pages/Users"
import Title from "./pages/Front/Title"
import Login from "./pages/Auth/Login"
import Register from "./pages/Auth/Register"
import NotFound from "./pages/Special/NotFound"
import List from "./pages/Users/List"
import Create from "./pages/Users/Create"

import './App.css';

const App = () => {
  return (
    <>
    <Routes>
      <Route path='/' element={<FrontLayout />}>
        <Route index element={<Title />} />
      </Route>
      <Route path='/account' element={<AuthLayout />}>
        <Route path='/account/login' element={<Login />} />
        <Route path='/account/register' element={<Register />} />
      </Route>
      <Route path='/users' element={<UsersLayout />}>
        <Route index element={<List />} />
        <Route path='/users/create' element={<Create />} />
      </Route>
      <Route path="*" element={<NotFound />} />
    </Routes>
    </>
  );
}

export default App;