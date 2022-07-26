import React from 'react';  
import AddCustomer from './Customer/Add';  
import Customerlist from './Customer/List';  
import EditCustomer from './Customer/Edit';  
import { BrowserRouter, Routes, Route, Link } from 'react-router-dom';  
import './App.css';  
function App() {  
  return (  
    <BrowserRouter>  
      <div className="container">  
        <nav className="navbar navbar-expand-lg navheader">  
          <div className="collapse navbar-collapse" >  
            <ul className="navbar-nav mr-auto">  
              <li className="nav-item">  
                <Link to={'/AddCustomer'} className="nav-link">AddCustomer</Link>  
              </li>  
              <li className="nav-item">  
                <Link to={'/CustomerList'} className="nav-link">Customer List</Link>  
              </li>  
            </ul>  
          </div>  
        </nav> <br />  
        <Routes>  
          <Route exact path='/Add' component={AddCustomer} />  
          <Route path='/Edit/:id' component={EditCustomer} />  
          <Route path='/CustomerList' element={<Customerlist></Customerlist>} />  
        </Routes>  
      </div>  
    </BrowserRouter>  
  );  
}  
  
export default App;  
