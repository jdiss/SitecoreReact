import React, { Component } from 'react';
import Parser from 'html-react-parser';


export const Field = (name) => {
     const fieldName = name.replace(" ","_");
     let val = window.SitecoreReact && window.SitecoreReact[fieldName] && window.atob(window.SitecoreReact[fieldName]);
     let result = val ? Parser(val) : <div>Empty</div>
     return result;
}

export const Data = (name) => {
    const fieldName = name.replace(" ","_");
    let val = window.SitecoreReact && window.SitecoreReact.Data && window.SitecoreReact.Data[fieldName];
    return JSON.parse(val);
}