#include <iostream>
#include <fstream>
using namespace std;

struct Node
{
    Node* left = NULL;
    Node* right = NULL;
    int value = 0;
};

class Btree
{
private:
    Node* root = NULL;
    int TreePopulation = 0;

    void DeleteRec(Node** travel, int num)
    {
        if ((*travel)->value == num)
        {
            Node* Save;

            if ((*travel)->left && (*travel)->right)
            {
                Node** temp = &((*travel)->left);
                Node** Parent = travel;
                int count = 0;

                while (&(*temp)->right)
                {
                    if (count == 0)
                    {
                        Parent = &(*Parent)->left;
                    }
                    else if (count > 0)
                    {
                        Parent = &(*Parent)->right;
                    }
                    temp = &(*temp)->right;
                    count++;
                }

                (*travel)->value = (*temp)->value;

                Save = (*temp)->left;

                if (Save)
                {
                    if (count > 1)
                        (*Parent)->right = Save;
                    else
                        (*Parent)->left = Save;
                }
                delete* temp;
                *temp = Save;
            }
            else if ((*travel)->left && !(*travel)->right)
            {
                Save = (*travel)->left;

                delete* travel;
                *travel = Save;
            }
            else if (!(*travel)->left && (*travel)->right)
            {
                Save = (*travel)->right;

                delete* travel;
                *travel = Save;
            }
            else
            {
                delete* travel;
                *travel = NULL;
            }

            TreePopulation--;
        }

        else if ((*travel)->left && (*travel)->value > num)
        {
            DeleteRec(&((*travel)->left), num);
        }

        else if ((*travel)->right && (*travel)->value < num)
        {
            DeleteRec(&((*travel)->right), num);
        }

        else
        {
            cout << "Number not found" << endl;
        }
    }

    bool recSearch(Node* temp, int num)
    {
        if (temp->value == num)
        {
            return true;
        }
        else if (temp->left && num <= temp->value)
        {
            return recSearch(temp->left, num);

        }
        else if (temp->right && num > temp->value)
        {
            return recSearch(temp->right, num);
        }
        else
        {
            return false;
        }
    }

    void recinorder(Node* temp)
    {
        if (temp->left) 
        {
            recinorder(temp->left);
        }

        cout << temp->value << " ";
        

        if (temp->right)
        {
            recinorder(temp->right);
        }
    }

    void recClear(Node* travel)
    {
        if (travel->left)
        {
            recClear(travel->left);            
        }       

        if (travel->right)
        {
            recClear(travel->right);            
        }

        delete travel;
        travel = NULL;      
    }
    
    void RecWrite(Node* Travel, ofstream& File)
    {
        File << Travel->value << " ";

        if (Travel->left)
        {
            RecWrite(Travel->left, File);
        }

        if (Travel->right)
        {
            RecWrite(Travel->right, File);
        }
    }


public:
    void Add(int val)
    {
        if (!(root))
        {
            root = new Node;
            root->value = val;
        }
        else
        {
            Node* Travel = root;

            while (true)
            {
                if (Travel->value > val)
                {
                    if (!(Travel->left))
                    {
                        Travel->left = new Node;
                        Travel->left->value = val;
                        break;
                    }
                    else
                    {
                        Travel = Travel->left;
                    }
                }
                else
                {
                    if (!(Travel->right))
                    {
                        Travel->right = new Node;
                        Travel->right->value = val;
                        break;
                    }
                    else
                    {
                        Travel = Travel->right;
                    }
                }
            }
        }

        TreePopulation++;
    }

    void Delete(int num)
    {
        DeleteRec(&root, num);
    }

    ~Btree()
    {
        Clear();
    }

    void InOrder()
    {
        if (root)
        {
            recinorder(root);
            cout << endl;
        }
        else
        {
            cout << "Tree is empty" << endl;
        }
    }

    bool Search(int num)
    {
        bool Found = recSearch(root, num);

        if (Found)
        {
            cout << "The number was found." << endl;
        }
        else
        {
            cout << "The number was not found." << endl;
        }

        return Found;
    }

    void Balance()
    {
        int* NumArray = new int[TreePopulation];
        int counter = 0;
        RecCreateArray(root, NumArray, counter);

        int PopulationSave = TreePopulation;
        Clear();
        RecBalance(NumArray, 0, PopulationSave - 1);

        cout << "Tree should be Balanced.....maybe" << endl;
    }

    void RecCreateArray(Node* Travel, int NumArray[], int& Counter)
    {
        if (Travel->left)
        {
            RecCreateArray(Travel->left, NumArray, Counter);
        }

        NumArray[Counter++] = Travel->value;

        if (Travel->right)
        {
            RecCreateArray(Travel->right, NumArray, Counter);
        }
    }

    void RecBalance(int NumArray[], int Leftside, int Rightside)//like partition in quick sort
    {
        int Size = Rightside - Leftside;

        if (Size > 0)
        {
            int Mid = (Rightside + Leftside) / 2;

            Add(NumArray[Mid]);

            int NewLeftside = Mid + 1;
            int NewRightside = Mid - 1;

            RecBalance(NumArray, NewLeftside, Rightside);
            RecBalance(NumArray, Leftside, NewRightside);
        }
        else if (Size == 0)
        {
            Add(NumArray[Leftside]);
        }
    }

    void Clear()
    {
        recClear(root);
        root = NULL;
        TreePopulation = 0;
        cout << "tree has been Cleared" << endl;
    }

    void Save()
    {
        if (!root)
        {
            cout << "Tree is empty" << endl;
            return;
        }

        Balance();
        char FileName[30];

        cout << "Enter File Name-> ";

        cin >> FileName;

        ofstream File(FileName);
        RecWrite(root, File);

        cout << "Btree is located at " << FileName << endl;
    }

    void Load()
    {
        if (root)
        {
            Clear();
        }

        char FileName[30];

        cout << "Enther the name of the file you want to load -> ";

        cin >> FileName;

        ifstream File(FileName);

        if (File.is_open())
        {
            int Num;

            while (true)
            {
                File >> Num;
                if (File.eof())
                {
                    break;
                }

                Add(Num);
            }

            cout << "Load Successful" << endl;
        }
        else
        {
            cout << " File not found" << endl;
        }
    }


};

int main()
{
    Btree Tree;
    bool Running = true;
    int selection;

    while (Running)
    {
        cout << "1) Add item" << endl;
        cout << "2) Delete" << endl;
        cout << "3) Search" << endl;
        cout << "4) Clear" << endl;
        cout << "5) Balance" << endl;
        cout << "6) Print in Order" << endl;
        cout << "7) Save" << endl;
        cout << "8) Load" << endl;
        cout << "9) Exit" << endl;
        cout << "Enter number -> ";

        cin >> selection;

        int input;
        bool Located;

        switch (selection)
        {
        case 1:
            cout << "Enter a number to add -> ";
            cin >> input;

            Tree.Add(input);
            break;

        case 2:
            cout << "Enter a number to delete -> ";
            cin >> input;

            Tree.Delete(input);
            break;
        case 3:
            cout << "Enter a number to search -> ";
            cin >> input;

            Located = Tree.Search(input);

            if (Located)
            {
                cout << input << " was located" << endl;
            }
            else
            {
                cout << input << " was not located" << endl;
            }
            break;
        case 4:
            Tree.Clear();
            break;
        case 5:
            Tree.Balance();
            break;
        case 6:
            Tree.InOrder();
            break;
        case 7:
            Tree.Save();
            break;
        case 8:
            Tree.Load();
            break;
        case 9:
            Running = false;
            break;
        }
    }
    return 0;
}

