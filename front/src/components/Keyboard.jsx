import React from 'react';

function Keyboard({ setter }) {
  return (
      <table className="table table-borderless">
          <tbody>
              <tr>
                  <th><div className="d-grid"><button className="btn btn-secondary" onClick={() => setter('1')}>1</button></div></th>
                  <th><div className="d-grid"><button className="btn btn-secondary" onClick={() => setter('2')}>2</button></div></th>
                  <th><div className="d-grid"><button className="btn btn-secondary" onClick={() => setter('3')}>3</button></div></th>
              </tr>
              <tr>
                  <th><div className="d-grid"><button className="btn btn-secondary" onClick={() => setter('4')}>4</button></div></th>
                  <th><div className="d-grid"><button className="btn btn-secondary" onClick={() => setter('5')}>5</button></div></th>
                  <th><div className="d-grid"><button className="btn btn-secondary" onClick={() => setter('6')}>6</button></div></th>
              </tr>
              <tr>
                  <th><div className="d-grid"><button className="btn btn-secondary" onClick={() => setter('7')}>7</button></div></th>
                  <th><div className="d-grid"><button className="btn btn-secondary" onClick={() => setter('8')}>8</button></div></th>
                  <th><div className="d-grid"><button className="btn btn-secondary" onClick={() => setter('9')}>9</button></div></th>
              </tr>
              <tr>
                  <th></th>
                  <th><div className="d-grid"><button className="btn btn-secondary" onClick={() => setter('0')}>0</button></div></th>
                  <th></th>
              </tr>
          </tbody>
      </table>
  );
}

export default Keyboard;